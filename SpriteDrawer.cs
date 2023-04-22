using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAGIDE {
    internal class SpriteDrawer {

        Image Result;
        Image Sprite;
        public int FrameWidth = 0;
        public int FrameHeight = 0;
        public int Frame = 0;

        int ImageWidth = 128;
        int ImageHeight = 128;


        public Image Draw() {
            Result = new Bitmap(ImageWidth, ImageHeight);
            
            if (Sprite != null) {
                var spriteWidth = (int)Sprite.Width;
                var spriteHeight = (int)Sprite.Height;

                var FrameOffsetX = 0;
                var FrameOffsetY = 0;
                while (Frame > 0) {
                    FrameOffsetX++;
                    if ((FrameOffsetX)* FrameWidth >= spriteWidth) {
                        FrameOffsetY++;
                        FrameOffsetX = 0;
                    }
                    Frame--;
                }

                var SpriteOffsetX = -FrameWidth/2 - FrameWidth * FrameOffsetX;
                var SpriteOffsetY = -FrameHeight/2 - FrameHeight * FrameOffsetY;
                var CentreX = ImageWidth / 2;
                var CentreY = ImageHeight / 2;

                using (Graphics g = Graphics.FromImage(Result)) {

                    Pen pen = new Pen(Color.Red, 1);
                    g.DrawLine(pen, (CentreX - FrameWidth), (CentreY - FrameHeight), (CentreX + FrameWidth), (CentreY + FrameHeight));

                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                    g.ScaleTransform(2.0f, 2.0f);
                    g.DrawImage(Sprite, new Point(CentreX/2 + SpriteOffsetX, CentreY/2 + SpriteOffsetY)); // You can adjust the location as needed


                    
                }

                using (Graphics g = Graphics.FromImage(Result)) {

                    Pen pen = new Pen(Color.Black, 1);

                    for(var i = 0; i < spriteWidth; i += FrameWidth) {
                        for (var j = 0; j < spriteHeight; j += FrameHeight) {
                            g.DrawRectangle(pen, new Rectangle(CentreX+i*2+ SpriteOffsetX*2, CentreY+j*2+ SpriteOffsetY*2, FrameWidth * 2, FrameHeight * 2));
                        }
                    }

                    pen = new Pen(Color.Red, 1);

                    //g.DrawLine(pen, (CentreX - FrameWidth), (CentreY - FrameHeight), (CentreX + FrameWidth), (CentreY - FrameHeight));
                    //g.DrawLine(pen, (CentreX - FrameWidth), (CentreY + FrameHeight), (CentreX + FrameWidth), (CentreY + FrameHeight));
                    //g.DrawLine(pen, (CentreX - FrameWidth), (CentreY - FrameHeight), (CentreX - FrameWidth), (CentreY + FrameHeight));
                    //g.DrawLine(pen, (CentreX + FrameWidth), (CentreY - FrameHeight), (CentreX + FrameWidth), (CentreY + FrameHeight));


                    g.DrawRectangle(pen, new Rectangle(CentreX - FrameWidth, CentreY - FrameHeight, FrameWidth*2, FrameHeight*2));

                }
            }

            return Result;
        }

        public void LoadSprite(string path) {
            if (File.Exists(path)) {
                Sprite = Image.FromFile(path);
            }
        }
    }
}
