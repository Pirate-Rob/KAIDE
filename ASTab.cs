using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAGIDE
{
    internal class ASTab : TabPage
    {
        private bool OnlyRead = false;
        Scintilla scintilla;

        public ASTab(string path, bool onlyread)
        {
            this.Text = Path.GetFileName(path);
            this.Tag = path;
            this.OnlyRead = onlyread;

            //RichTextBox richTextBox = new RichTextBox { Dock = DockStyle.Fill, Text = File.ReadAllText(path) };
            scintilla = new Scintilla { Dock = DockStyle.Fill, Text = File.ReadAllText(path) };
            scintilla.Lexer = Lexer.Cpp;
            scintilla.EmptyUndoBuffer();

            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 12;
            scintilla.Styles[Style.Default].ForeColor = Color.LightGray;
            scintilla.Styles[Style.Default].BackColor = Color.FromArgb(22, 14, 32);
            scintilla.StyleClearAll();

            // Configure the lexer styles
            scintilla.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            //Comments obviously
            scintilla.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(128, 255, 128); // Pastal Green
            scintilla.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(128, 255, 128); // Pastal Green
            scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 255, 128); // Pastal Green
            ///Used for data types
            scintilla.Styles[Style.Cpp.Word].ForeColor = Color.FromArgb(128, 128, 192); // Pastal Blue
            scintilla.Styles[Style.Cpp.Word].Bold = true;
            //Used for member functions
            scintilla.Styles[Style.Cpp.Word2].ForeColor = Color.FromArgb(128, 192, 255); // Pastal Cyan
            //Literals
            scintilla.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(255, 128, 128); // Pastal Red
            scintilla.Styles[Style.Cpp.Number].ForeColor = Color.FromArgb(255, 128, 128); // Pastal Red
            scintilla.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            //Used for #include files
            scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = Color.FromArgb(192, 64, 64); //Pasal Maroon
            //Using GlobalClass for the global Functions
            scintilla.Styles[Style.Cpp.GlobalClass].ForeColor = Color.FromArgb(255, 192, 128); // Pastal Orange
            scintilla.Styles[Style.Cpp.GlobalClass].Italic = true;
            //Unsused/Unknown
            scintilla.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            scintilla.Styles[Style.Cpp.Operator].ForeColor = Color.LightGray;
            scintilla.Styles[Style.Cpp.Operator].Bold = true;

            scintilla.CaretForeColor = Color.White;

            scintilla.MouseUp += Scintilla_MouseUp;

            scintilla.CharAdded += Scintilla_CharAdded;
            scintilla.TextChanged += Scintilla_TextChanged;

            scintilla.AutoCIgnoreCase = true;
            scintilla.AutoCSeparator = '-';
            scintilla.AutoCOrder = Order.PerformSort;

            scintilla.UseTabs = true;

            scintilla.Margins[0].Width = 32; //Sets the number margin to actually have a non-0 width
            scintilla.Margins[1].Width = 0; //Sets the blank margin to have 0 width

            String control_flow = "if for while";
            String data_types = "void int f32 true false class bool";
            String common_var_names = "this sprite";

            //TODO: cache the result of this
            string functions = "";
            foreach (Tuple<string, string, string> tuple in KAGScraper.functionList.AsEnumerable())
            {
                functions += tuple.Item2 + " ";
            }
            string fields = "";
            foreach (Tuple<string, List<Tuple<string, string, string>>> tuple in KAGScraper.classFunctionList.AsEnumerable())
            {
                data_types += " " + tuple.Item1;
                foreach (Tuple<string, string, string> function in tuple.Item2.AsEnumerable())
                {
                    fields += function.Item2 + " ";
                }
            }
            scintilla.SetKeywords(0, control_flow + " " + data_types + " " + common_var_names);
            scintilla.SetKeywords(1, fields.Trim());
            scintilla.SetKeywords(3, functions.Trim());

            var toolStrip = new ToolStrip();

            if (!OnlyRead)
            {
                var saveButton = new ToolStripButton("Save");
                toolStrip.Items.Add(saveButton);
                saveButton.Click += (sender, e) =>
                {
                    // Save the file
                    CommitSave(path);
                };
            }

            var closeButton = new ToolStripButton("Close");
            toolStrip.Items.Add(closeButton);
            closeButton.Alignment = ToolStripItemAlignment.Right;
            closeButton.Click += (sender, e) => {
                // Close the tab
                //Tabs.TabPages.Remove(Page);
                TabManager.CloseTab((string)this.Tag);
            };


            
            

            Panel panel = new Panel { Dock = DockStyle.Fill };
            panel.Controls.Add(scintilla);
            panel.Controls.Add(toolStrip);
            this.Controls.Add(panel);
            
        }


        private static void Scintilla_MouseUp(object sender, MouseEventArgs e)
        {
            Scintilla scintilla = sender as Scintilla;
            Console.WriteLine("SelectedText: " + scintilla.SelectedText);
            scintilla.IndicatorClearRange(0, scintilla.TextLength);
            HighlightWord(scintilla, scintilla.SelectedText);
        }

        private static void HighlightWord(Scintilla scintilla, string text)
        {
            if (string.IsNullOrEmpty(text))
                return;

            // Indicators 0-7 could be in use by a lexer
            // so we'll use indicator 8 to highlight words.
            const int NUM = 8;

            // Remove all uses of our indicator
            scintilla.IndicatorCurrent = NUM;

            // Update indicator appearance
            scintilla.Indicators[NUM].Style = IndicatorStyle.StraightBox;
            scintilla.Indicators[NUM].Under = true;
            scintilla.Indicators[NUM].ForeColor = Color.FromArgb(192, 128, 192);
            scintilla.Indicators[NUM].OutlineAlpha = 100;
            scintilla.Indicators[NUM].Alpha = 75;

            // Search the document
            scintilla.TargetStart = 0;
            scintilla.TargetEnd = scintilla.TextLength;
            scintilla.SearchFlags = SearchFlags.None;
            while (scintilla.SearchInTarget(text) != -1)
            {
                // Mark the search results with the current indicator
                scintilla.IndicatorFillRange(scintilla.TargetStart, scintilla.TargetEnd - scintilla.TargetStart);

                // Search the remainder of the document
                scintilla.TargetStart = scintilla.TargetEnd;
                scintilla.TargetEnd = scintilla.TextLength;
            }
        }


        private static void Scintilla_CharAdded(object sender, CharAddedEventArgs e)
        {
            Scintilla scintilla = sender as Scintilla;

            // Find the word start
            var currentPos = scintilla.CurrentPosition;
            var wordStartPos = scintilla.WordStartPosition(currentPos, true);

            //string lastChar = scintilla.Text.Substring(currentPos-1, 1);
            char lastChar = (char)e.Char;

            if (lastChar == '.')
            {

                var scopePos = scintilla.WordStartPosition(currentPos - 1, true);
                var scope = scintilla.Text.Substring(scopePos, currentPos - scopePos - 1);
                var codeUpToThisPoint = scintilla.Text.Substring(0, scopePos);

                Console.WriteLine("codeUpToThisPoint: " + codeUpToThisPoint);

                HashSet<string> keywords = new HashSet<string>();
                foreach (Tuple<string, List<Tuple<string, string, string>>> tuple in KAGScraper.classFunctionList.AsEnumerable())
                {
                    keywords.Add(tuple.Item1);
                }

                Console.WriteLine("keywords: " + keywords.Count);

                string token = FindTokensWithKeywordBefore(codeUpToThisPoint, scope, keywords);

                Console.WriteLine("token: " + token);

                string functions = "";

                foreach (Tuple<string, List<Tuple<string, string, string>>> tuple in KAGScraper.classFunctionList.AsEnumerable())
                {
                    if (token == tuple.Item1)
                        foreach (Tuple<string, string, string> function in tuple.Item2.AsEnumerable())
                        {
                            functions += function.Item3 + scintilla.AutoCSeparator;
                        }
                }
                functions = functions.Trim();

                if (functions != "")
                {
                    if (!scintilla.AutoCActive)
                        scintilla.AutoCShow(0, functions);
                }
                else
                {

                }

            }
            else
            {// Display the default autocompletion list

                //TODO: cache the result of this
                string functions = "";
                foreach (Tuple<string, string, string> tuple in KAGScraper.functionList.AsEnumerable())
                {
                    functions += tuple.Item3 + scintilla.AutoCSeparator;
                }
                functions = functions.Trim();

                var lenEntered = currentPos - wordStartPos;
                if (lenEntered > 0)
                {
                    if (!scintilla.AutoCActive)
                        scintilla.AutoCShow(lenEntered, functions);
                }
            }
        }

        private static string FindTokensWithKeywordBefore(string input, string specificToken, HashSet<string> keywords)
        {
            // Tokenize the input string
            var tokens = new List<string>(input.Split(new[] { ' ', '\t', '\n', '\r', '.', ';', '@', '(', ')', '{', '}', '[', ']' }, StringSplitOptions.RemoveEmptyEntries));
            var specificTokenIndices = new List<int>();

            // Find all instances of the specific token
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == specificToken)
                {
                    specificTokenIndices.Add(i);
                }
            }

            Console.WriteLine("found " + specificTokenIndices.Count + " instances of " + specificToken);

            // Loop backwards over the specific token instances
            for (int i = specificTokenIndices.Count - 1; i >= 0; i--)
            {
                int tokenIndex = specificTokenIndices[i];

                Console.WriteLine(tokens[tokenIndex - 1]);

                // Check the token directly before the specific token
                if (tokenIndex > 0 && keywords.Contains(tokens[tokenIndex - 1]))
                {
                    return tokens[tokenIndex - 1];
                }
            }

            return "";
        }

        private void Scintilla_TextChanged(object sender, EventArgs e)
        {
            Scintilla scintilla = sender as Scintilla;

            string TabName = Path.GetFileName((string)this.Tag);
            if (scintilla.Modified) this.Text = TabName + "*";
            else this.Text = TabName;
        }

        private bool CommitSave(string path)
        {
            if (!OnlyRead)
            {
                File.WriteAllText(path, scintilla.Text);
                scintilla.SetSavePoint();
                this.Text = Path.GetFileName((string)this.Tag);
                return true;
            }
            return false;
        }
    }
}
