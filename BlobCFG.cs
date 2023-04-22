using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class BlobCFG
{
    public string FilePath { get; private set; }

    private Stack<Change> undoStack;
    private Stack<Change> redoStack;
    private int lastSavedChangeCount;

    public BlobCFG(string filePath)
    {
        FilePath = filePath;
        undoStack = new Stack<Change>();
        redoStack = new Stack<Change>();
        lastSavedChangeCount = 0;
    }

    public void Load()
    {
        using (StreamReader reader = new StreamReader(FilePath))
        {
            string line;

            string arrayName = "";
            List<string> arrayContents = new List<string>();
            //This is so horrible
            List<GibSettings> Gibs = new List<GibSettings>();
            GibSettings currentGib = null;
            //I'm sure there must be a better way to do this
            List<AttachmentPoint> Attachments = new List<AttachmentPoint>();
            AttachmentPoint currentAttachment = null;
            //Aaaaaaaaaa, animations are cursed
            bool CompilingAnimations = false;
            string currentAnimName = "";
            List<AnimationSettings> Animations = new List<AnimationSettings>();
            AnimationSettings currentAnimation = null;


            while ((line = reader.ReadLine()) != null)
            {
                int commentIndex = line.IndexOf('#');
                if (commentIndex >= 0)line = line.Substring(0, commentIndex);
                line = line.Trim();
                if (line.Contains("="))
                {
                    if (arrayName != "") //If we're busy with an array and we come across a value, the array is 'obviously' complete
                    {
                        SetValue(arrayName, arrayContents.ToArray());
                        arrayName = "";
                        arrayContents.Clear();
                    }

                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string valuestr = parts.Length > 1 ? parts[1].Trim() : "";
                    object value = null;

                    Console.WriteLine(key + ": " + valuestr);

                    if (key == "$sprite_animation_start")
                    {
                        CompilingAnimations = true;
                        continue;
                    }
                    if (key == "$sprite_animation_end")
                    {
                        CompilingAnimations = false;
                        continue;
                    }

                    if(CompilingAnimations && key.Contains("animation")) //This is so terrible
                    {
                        if(key.Contains("name"))
                        {
                            currentAnimation = new AnimationSettings();
                            currentAnimation.AnimationName = valuestr;
                        }
                        if(currentAnimation != null)
                        {
                            if (key.Contains("time"))
                            {
                                currentAnimation.AnimationTime = int.Parse(valuestr);
                            }
                            if (key.Contains("loop"))
                            {
                                currentAnimation.AnimationLoop = int.Parse(valuestr);
                            }
                            if (key.Contains("frames"))
                            {
                                string[] values = valuestr.Split(';');
                                List<int> frames = new List<int>();
                                foreach (string num in values)
                                {
                                    int frame;
                                    if (int.TryParse(num.Trim(), out frame))
                                    {
                                        frames.Add(frame);
                                    }
                                }
                                currentAnimation.AnimationFrames = frames.ToArray();
                            }
                        }
                    }
                    


                    if (line.StartsWith("@"))
                    {
                        arrayName = key;
                        arrayContents.Add(line);
                    }
                    else
                    if (line.StartsWith("u8") || line.StartsWith("s8") || line.StartsWith("u16") || line.StartsWith("s16") || line.StartsWith("u32") || line.StartsWith("s32"))
                    {
                        value = int.Parse(valuestr);
                    }
                    else
                    if (line.StartsWith("f32"))
                    {
                        value = float.Parse(valuestr, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture);
                    }
                    else
                    if (line.StartsWith("bool"))
                    {
                        value = false;
                        if (valuestr == "yes" || valuestr == "true") value = true;
                    }
                    else
                    {
                        value = valuestr;
                    }

                    if (key == "$gib_type")
                    {
                        currentGib = new GibSettings();
                        Gibs.Add(currentGib);
                    }

                    if (currentGib != null){
                        currentGib.SetValue(key, value);
                    }
                    SetValue(key, value);
                }
                else
                if(arrayName != "" && line != "")
                {
                    arrayContents.Add(line);
                    Console.WriteLine("Added "+line+" to array '"+ arrayName + "'");
                }
            }

            SetValue("gibs", Gibs.ToArray());
            SetValue("animations", Animations.ToArray());
        }
    }

    public void Save()
    {
        /*
        using (StreamWriter writer = new StreamWriter(FilePath))
        {
            foreach (var property in Properties)
            {
                if (property.Value is string)
                {
                    writer.WriteLine($"{property.Key} = {property.Value}");
                }
                else if (property.Value is string[])
                {
                    writer.WriteLine($"{property.Key} = {string.Join("; ", (string[])property.Value)}");
                }
            }
        }*/
        lastSavedChangeCount = undoStack.Count;
    }

    public void SetProperty(string key, object value)
    {
        object oldVal = SetValue(key, value);
        undoStack.Push(new Change(key, oldVal));
        redoStack.Clear();
    }

    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            Change change = undoStack.Pop();
            redoStack.Push(change);
            SetValue(change.Key, change.Value);
        }
    }

    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            Change change = redoStack.Pop();
            undoStack.Push(change);
            SetValue(change.Key, change.Value);
        }
    }

    public bool IsDirty()
    {
        return undoStack.Count != lastSavedChangeCount;
    }

    private class Change
    {
        public string Key { get; private set; }
        public object Value { get; private set; }

        public Change(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }

    public object SetValue(string key, object value)
    {
        object oldVal = null;
        switch (key)
        {
            case "$sprite_factory":
                oldVal = SpriteFactory;
                SpriteFactory = (string)value;
                break;
            case "$sprite_scripts":
                oldVal = SpriteScripts;
                SpriteScripts = (string[])value;
                break;
            case "$sprite_texture":
                oldVal = SpriteTexture;
                SpriteTexture = (string)value;
                break;
            case "s32_sprite_frame_width":
                oldVal = SpriteFrameWidth;
                SpriteFrameWidth = (int)value;
                break;
            case "s32_sprite_frame_height":
                oldVal = SpriteFrameHeight;
                SpriteFrameHeight = (int)value;
                break;
            case "f32 sprite_offset_x":
                oldVal = SpriteOffsetX;
                SpriteOffsetX = (float)value;
                break;
            case "f32 sprite_offset_y":
                oldVal = SpriteOffsetY;
                SpriteOffsetY = (float)value;
                break;

            case "gibs":
                oldVal = Gibs;
                Gibs = (GibSettings[])value;
                break;

            case "animations":
                oldVal = Animations;
                Animations = (AnimationSettings[])value;
                break;

            case "$shape_factory":
                oldVal = ShapeFactory;
                ShapeFactory = (string)value;
                break;
            case "$shape_scripts":
                oldVal = ShapeScripts;
                ShapeScripts = (string[])value;
                break;
            case "f32 shape_mass":
                oldVal = ShapeMass;
                ShapeMass = (float)value;
                break;
            case "f32 shape_radius":
                oldVal = ShapeRadius;
                ShapeRadius = (float)value;
                break;
            case "f32 shape_friction":
                oldVal = ShapeFriction;
                ShapeFriction = (float)value;
                break;
            case "f32 shape_elasticity":
                oldVal = ShapeElasticity;
                ShapeElasticity = (float)value;
                break;
            case "f32 shape_buoyancy":
                oldVal = ShapeBuoyancy;
                ShapeBuoyancy = (float)value;
                break;
            case "f32 shape_drag":
                oldVal = ShapeDrag;
                ShapeDrag = (float)value;
                break;
            case "bool shape_collides":
                oldVal = ShapeCollides;
                ShapeCollides = (bool)value;
                break;
            case "bool shape_ladder":
                oldVal = ShapeLadder;
                ShapeLadder = (bool)value;
                break;
            case "bool shape_platform":
                oldVal = ShapePlatform;
                ShapePlatform = (bool)value;
                break;
            case "@f32 verticesXY":
                //oldVal = ShapeVerticesXY;
                //ShapeVerticesXY = (float[])value;
                break;
            case "u8 block_support":
                oldVal = BlockSupport;
                BlockSupport = (int)value;
                break;
            case "bool block_background":
                oldVal = BlockBackground;
                BlockBackground = (bool)value;
                break;
            case "bool block_lightpasses":
                oldVal = BlockLightpasses;
                BlockLightpasses = (bool)value;
                break;
            case "bool block_snaptogrid":
                oldVal = BlockSnaptogrid;
                BlockSnaptogrid = (bool)value;
                break;

            //General
            case "$name":
                oldVal = Name;
                Name = (string)value;
                break;
            case "$inventory_name":
                oldVal = InventoryName;
                InventoryName = (string)value;
                break;
            case "$inventory_icon":
                oldVal = InventoryIcon;
                InventoryIcon = (string)value;
                break;
            case "f32 health":
                oldVal = Health;
                Health = (float)value;
                break;
            case "u8 inventory_icon_frame":
                oldVal = InventoryIconFrame;
                InventoryIconFrame = (int)value;
                break;
            case "u8 inventory_icon_frame_width":
                oldVal = InventoryIconFrameWidth;
                InventoryIconFrameWidth = (int)value;
                break;
            case "u8 inventory_icon_frame_height":
                oldVal = InventoryIconFrameHeight;
                InventoryIconFrameHeight = (int)value;
                break;
            case "u8 inventory_used_width":
                oldVal = InventoryUsedWidth;
                InventoryUsedWidth = (int)value;
                break;
            case "u8 inventory_used_height":
                oldVal = InventoryUsedHeight;
                InventoryUsedHeight = (int)value;
                break;
            case "u8 inventory_max_stacks":
                oldVal = InventoryMaxStacks;
                InventoryMaxStacks = (int)value;
                break;
        }
        return oldVal;
    }

    // Sprite settings
    public string SpriteFactory { get; private set; }
    public string[] SpriteScripts { get; private set; }
    public string SpriteTexture { get; private set; }
    public int SpriteFrameWidth { get; private set; }
    public int SpriteFrameHeight { get; private set; }
    public float SpriteOffsetX { get; private set; }
    public float SpriteOffsetY { get; private set; }

    // Gibbing settings
    public GibSettings[] Gibs { get; private set; }
    // Animation settings
    public AnimationSettings[] Animations { get; private set; }

    // Shape settings
    public string ShapeFactory { get; private set; }
    public string[] ShapeScripts { get; private set; }
    public float ShapeMass { get; private set; }
    public float ShapeRadius { get; private set; }
    public float ShapeFriction { get; private set; }
    public float ShapeElasticity { get; private set; }
    public float ShapeBuoyancy { get; private set; }
    public float ShapeDrag { get; private set; }
    public bool ShapeCollides { get; private set; }
    public bool ShapeLadder { get; private set; }
    public bool ShapePlatform { get; private set; }
    public float[] ShapeVerticesXY { get; private set; }
    public int BlockSupport { get; private set; }
    public bool BlockBackground { get; private set; }
    public bool BlockLightpasses { get; private set; }
    public bool BlockSnaptogrid { get; private set; }

    // Movement settings
    public string MovementFactory { get; private set; }
    public string[] MovementScripts { get; private set; }

    // Brain settings
    public string BrainFactory { get; private set; }
    public string[] BrainScripts { get; private set; }

    // Attachment settings
    public string AttachmentFactory { get; private set; }
    public string[] AttachmentScripts { get; private set; }
    public AttachmentPoint[] AttachmentPoints { get; private set; }

    // Inventory settings
    public string InventoryFactory { get; private set; }
    public string[] InventoryScripts { get; private set; }
    public string InventoryName { get; private set; }
    public string InventoryIcon { get; private set; }
    public int InventoryIconFrame { get; private set; }
    public int InventoryIconFrameWidth { get; private set; }
    public int InventoryIconFrameHeight { get; private set; }
    public int InventoryUsedWidth { get; private set; }
    public int InventoryUsedHeight { get; private set; }
    public int InventoryMaxStacks { get; private set; }

    // General settings
    public string Name { get; private set; }
    public string[] Scripts { get; private set; }
    public float Health { get; private set; }



    public class GibSettings
    {
        public string GibType { get; private set; }
        public string GibStyle { get; private set; }
        public int GibCount { get; private set; }
        public int[] GibFrame { get; private set; }
        public float Velocity { get; private set; }
        public float OffsetX { get; private set; }
        public float OffsetY { get; private set; }

        public object SetValue(string key, object value)
        {
            object oldVal = null;
            switch (key)
            {
                case "$gib_type":
                    oldVal = GibType;
                    GibType = (string)value;
                    break;
                case "$gib_style":
                    oldVal = GibStyle;
                    GibStyle = (string)value;
                    break;
                case "u8 gib_count":
                    oldVal = GibCount;
                    GibCount = (int)value;
                    break;
                case "@u8 gib_frame":
                    oldVal = GibFrame;
                    GibFrame = (int[])value;
                    break;
                case "f32 velocity":
                    oldVal = Velocity;
                    Velocity = (float)value;
                    break;
                case "f32 offset_x":
                    oldVal = OffsetX;
                    OffsetX = (float)value;
                    break;
                case "f32 offset_y":
                    oldVal = OffsetY;
                    OffsetY = (float)value;
                    break;
            }
            return oldVal;
        }
    }

    public class AnimationSettings
    {
        public string AnimationName { get; set; }
        public int AnimationTime { get; set; }
        public int AnimationLoop { get; set; }
        public int[] AnimationFrames { get; set; }
    }

    public class AttachmentPoint
    {
        public string Name { get; set; }
        public float OffsetX { get; set; }
        public float OffsetY { get; set; }
        public bool SocketPlug { get; set; }
        public bool Controller { get; set; }
        public float Radius { get; set; }
    }
}