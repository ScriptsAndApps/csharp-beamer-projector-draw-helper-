using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace projectimg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseWheel += new MouseEventHandler(MouseWheell);
            MouseWheel += new MouseEventHandler(MouseWheell);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor,true);

        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20; // WS_EX_TRANSPARENT
                return cp;
            }
        }
        void resizeandlotae(ref PictureBox pi, int ax, int timesorig = 0)
        {

            Size oldSize = pi.Size;
            Point middle = pi.Location;
            middle.X += pi.Width / 2;
            middle.Y += pi.Height / 2;
            int neww = 100;
            int newh = 100;
            if (timesorig<0) { 
                 neww = pi.Image.Width / -timesorig;
                 newh = pi.Image.Height / -timesorig;
                }
            else {
                 neww = timesorig != 0 ? pi.Image.Width * timesorig : pi.Width + ax;
                 newh = timesorig != 0 ? pi.Image.Height * timesorig : pi.Height + ax;
            }
            Size temps = ResizeKeepAspect(pi.Size, neww, newh, true);
            pi.Size = temps;
            Point newloc = new Point();
            newloc.X = middle.X-(pi.Width/2);
            newloc.Y = middle.Y - (pi.Height / 2);
            pi.Location =  newloc;
        }
        private void MouseWheell(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int numberOfTextLinesToMove = e.Delta * SystemInformation.MouseWheelScrollLines / 120;

            if (piccol.Length > 0 && selectedbox >= 0)
                    {
                try
                {
                    
                        if (numberOfTextLinesToMove < 0)
                            if (!(piccol[selectedbox].Height > 50 && piccol[selectedbox].Width > 50)) return;
                                 resizeandlotae(ref piccol[selectedbox], numberOfTextLinesToMove * 8);
                  
                }
                catch
                {
                }  return;
                    }
                if (numberOfTextLinesToMove < 0)
                    if (!(pictureBox1.Height > 50 && pictureBox1.Width > 50)) return;
                        resizeandlotae(ref pictureBox1, numberOfTextLinesToMove * 8);




        }


        public Size ResizeKeepAspect(Size src, int maxWidth, int maxHeight, bool enlarge = false)
        {
            maxWidth = enlarge ? maxWidth : Math.Min(maxWidth, src.Width);
            maxHeight = enlarge ? maxHeight : Math.Min(maxHeight, src.Height);

            decimal rnd = Math.Min(maxWidth / (decimal)src.Width, maxHeight / (decimal)src.Height);
            return new Size((int)Math.Round(src.Width * rnd), (int)Math.Round(src.Height * rnd));
        }

        private void pictureBox1_MarginChanged(object sender, EventArgs e)
        {
          
        }
        bool pictureboxhide = false;
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Text = e.KeyChar.ToString();
            if (e.KeyChar == (char)"-"[0])
            {
                if (piccol.Length > 0 && selectedbox >= 0)
                {
                    try
                    {
                        if (!(piccol[selectedbox].Height > 50 || piccol[selectedbox].Width > 50)) return;
                        resizeandlotae(ref piccol[selectedbox], -10);

                       
                    }
                    catch { } return;
                }
                if (!(pictureBox1.Height > 50 || pictureBox1.Width > 50)) return;
                resizeandlotae(ref pictureBox1, -10);
            }
            if (e.KeyChar == (char)"="[0] || e.KeyChar == (char)"+"[0])
            {
                if (piccol.Length > 0 && selectedbox >= 0)
                {
                    try
                    {
                        if (!(piccol[selectedbox].Height > 50 || piccol[selectedbox].Width > 50)) return;
                        resizeandlotae(ref piccol[selectedbox], 10);
                       
                    }
                    catch { } return;
                }
                if (!(pictureBox1.Height > 50 || pictureBox1.Width > 50)) return;
                resizeandlotae(ref pictureBox1, 10);
            }
            if (e.KeyChar == (char)"h"[0])
            {
                visable = !visable;
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == pictureBox1.GetType())
                    {
                        if (pictureboxhide && c.Name == "pictureBox1")
                        {
                            continue;
                        }
                        c.Visible = visable;
                        
                    }
                }
            }
            if (e.KeyChar == (char)"0"[0])
            {
                if (piccol.Length > 0 && selectedbox >= 0)
                {
                    try
                    {
                        piccol[selectedbox].Width = piccol[selectedbox].Image.Width;
                        piccol[selectedbox].Height = piccol[selectedbox].Image.Height;
                        piccol[selectedbox].Left = (Width / 2) - (piccol[selectedbox].Width / 2);
                        piccol[selectedbox].Top = (Height / 2) - (piccol[selectedbox].Height / 2);
                       
                    }
                    catch { } return;
                }
                this.pictureBox1.Width = pictureBox1.Image.Width;
                this.pictureBox1.Height = pictureBox1.Image.Height;
                pictureBox1.Left = (Width / 2) - (pictureBox1.Width / 2);
                pictureBox1.Top = (Height / 2) - (pictureBox1.Height / 2);
            }
            if (e.KeyChar == (char)"9"[0])
            {
                if (piccol.Length > 0 && selectedbox >= 0)
                {
                    try
                    {
                        resizeandlotae(ref piccol[selectedbox],0, 16);

                    }
                    catch { }
                        return;
                }
                resizeandlotae(ref pictureBox1, 0, 16);
            }
            if (e.KeyChar == (char)"8"[0])
            {
                if (piccol.Length > 0 && selectedbox >= 0)
                {
                    try
                    {
                        resizeandlotae(ref piccol[selectedbox], 0, 8);
                       
                    }
                    catch { } return;
                }
                resizeandlotae(ref pictureBox1, 0, 8);
            }
            if (e.KeyChar == (char)"7"[0])
            {
                if (piccol.Length > 0 && selectedbox >= 0)
                {
                    try
                    {
                        resizeandlotae(ref piccol[selectedbox], 0, 4);
                       
                    }
                    catch { } return;
                }
                resizeandlotae(ref pictureBox1, 0, 4);
            }
            if (e.KeyChar == (char)"6"[0])
            {
                if (piccol.Length > 0 && selectedbox >= 0)
                {
                    try
                    {
                        resizeandlotae(ref piccol[selectedbox], 0, 2);
                        
                    }
                    catch { }return;
                }
                resizeandlotae(ref pictureBox1, 0, 2);
            }
            if (e.KeyChar == (char)"5"[0])
            {
                if (piccol.Length > 0 && selectedbox >= 0)
                {
                    try
                    {
                        resizeandlotae(ref piccol[selectedbox], 0, 4);
                    
                    }
                    catch { }    return;
                }
                resizeandlotae(ref pictureBox1, 0, -4);
            }
            if (e.KeyChar == (char)"4"[0])
            {
                if (piccol.Length > 0 && selectedbox >= 0)
                {
                    try
                    {
                        resizeandlotae(ref piccol[selectedbox], 0, -8);
                       
                    }
                    catch { } return;
                }
                resizeandlotae(ref pictureBox1, 0, -8);
            }
            if (e.KeyChar == (char)"3"[0])
            {
                if (piccol.Length > 0 && selectedbox >= 0)
                {
                    try
                    {
                        resizeandlotae(ref piccol[selectedbox], 0, -10);
                        
                    }
                    catch { }return;
                }
                resizeandlotae(ref pictureBox1, 0, -10);
            }
            if (e.KeyChar == (char)"2"[0])
            {
                if (piccol.Length > 0 && selectedbox >= 0)
                {
                    try
                    {
                        resizeandlotae(ref piccol[selectedbox], 0, -16);
                       
                    }
                    catch { } return;
                }
                resizeandlotae(ref pictureBox1, 0, -16);
            }
            if (e.KeyChar == (char)"1"[0])
            {
                if (piccol.Length > 0 && selectedbox >= 0)
                {
                    try
                    {
                        resizeandlotae(ref piccol[selectedbox], 0, -32);
                       
                    }
                    catch { } return;
                }
                resizeandlotae(ref pictureBox1, 0, -32);
                
            }
            if (e.KeyChar == (char)"n"[0])
            {
                pictureBox1.Show();
                pictureBox1.Width = pictureBox1.Image.Width;
                pictureBox1.Height = pictureBox1.Image.Height;
                pictureBox1.Left = (Width / 2) - (pictureBox1.Width / 2);
                pictureBox1.Top = (Height / 2) - (pictureBox1.Height / 2);
                pictureboxhide = false;
                visable = true;
                if (piccol.Length > 0)
                {
                    try
                    {
                        foreach (PictureBox delp in piccol)
                        {
                            if (delp != null)
                            {
                                Controls.Remove(delp);
                            }
                        }

                    }
                    catch { }
                    return;
                }
                piccol = new PictureBox[0];
                downlist = new int[0];
                loclist = new Point[0];
            }
        }
        bool visable = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Width = pictureBox1.Image.Width;
            this.pictureBox1.Height = pictureBox1.Image.Height;
            pictureBox1.Left = (Width / 2) - (pictureBox1.Width / 2);
            pictureBox1.Top = (Height/ 2) - (pictureBox1.Height / 2);

            label1.Left = (Width / 2) - (label1.Width / 2);
            label1.Top = pictureBox1.Top + pictureBox1.Height +10;

        }
        bool isdown = false;
        Point loc1 = new Point(0,0);

        long milliseconds = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
        long lst = 0;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isdown)
            {
                milliseconds =(long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
                if (lst == 0 || milliseconds > lst)
                {
                    int offsetx = e.X - loc1.X;
                    int offsety = e.Y - loc1.Y;
                    this.pictureBox1.Left += offsetx;
                    this.pictureBox1.Top += offsety;
                    lst = milliseconds+10;
                }
            }
            else
            {
                loc1 = e.Location;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isdown = true;
            selectedbox = -1;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isdown = false;
        }
        bool isfdo = false;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isfdo=true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isfdo = false;
        }

        Point loc = new Point(0, 0);
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isfdo && visable)
            {
                int offsetx = e.X - loc.X;
                int offsety = e.Y - loc.Y;
                foreach (Control c in this.Controls)
                {
                    if (c.GetType() == pictureBox1.GetType())
                    {
                        c.Left += offsetx;
                        c.Top += offsety;
                    }
                }

                    loc = e.Location;
            }
            else
            {
                loc = e.Location;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (xtime == 1)
            {
                if (Keys.Delete == e.KeyCode)
                {
                    if (piccol.Length > 0 && selectedbox >= 0)
                    {
                        try
                        {
                            //remove
                            Controls.Remove(piccol[selectedbox]);
                            piccol[selectedbox] = null;
                            //end
                            xtime = 0;
                        }
                        catch { } return;
                    }
                    pictureBox1.Hide();
                    pictureboxhide = true;
                    
                    

                }
                if (Keys.Left == e.KeyCode)
                {
                    if (piccol.Length > 0 && selectedbox >= 0)
                    {
                        try
                        {
                           if (ModifierKeys.HasFlag(Keys.Shift))
                            {
                                piccol[selectedbox].Left -= 20;
                            }
                            piccol[selectedbox].Left -= 1;
                            xtime = 0;
                        }
                        catch { } return;
                    }
                    if (ModifierKeys.HasFlag(Keys.Shift))
                    {
                        pictureBox1.Left -= 20;
                    }
                    pictureBox1.Left -= 1;
                }
                if (Keys.Escape == e.KeyCode)
                {
                    
                   DialogResult res = MessageBox.Show("                   ----[ Exit? ]----","Beamer app",MessageBoxButtons.YesNo);
                    if(res == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                 
                }
                if (Keys.Right == e.KeyCode)
                {
                    if (piccol.Length > 0 && selectedbox >= 0)
                    {
                        try
                        {
                            if (ModifierKeys.HasFlag(Keys.Shift))
                            {
                                piccol[selectedbox].Left += 20;
                            }
                            piccol[selectedbox].Left += 1;
                            xtime = 0; 
                        }
                        catch { }return;
                    }
                    if (ModifierKeys.HasFlag(Keys.Shift))
                    {
                        pictureBox1.Left += 20;
                    }
                    pictureBox1.Left += 1;
                }
                if (Keys.Up == e.KeyCode)
                {
                    if (piccol.Length > 0 && selectedbox >= 0)
                    {
                        try
                        {
                            if (ModifierKeys.HasFlag(Keys.Shift))
                            {
                                piccol[selectedbox].Top -= 20;
                            }
                            piccol[selectedbox].Top -= 1;
                            xtime = 0; 
                        }
                        catch { }return;
                    }
                    if (ModifierKeys.HasFlag(Keys.Shift))
                    {
                        pictureBox1.Top -= 20;
                    }
                    pictureBox1.Top -= 1;
                }
                if (Keys.Down == e.KeyCode)
                {
                    if (piccol.Length > 0 && selectedbox >= 0)
                    {
                        try
                        {
                            if (ModifierKeys.HasFlag(Keys.Shift))
                            {
                                piccol[selectedbox].Top += 20;
                            }
                            piccol[selectedbox].Top += 1;
                            xtime = 0; 
                        }
                        catch { }return;
                    }
                    if (ModifierKeys.HasFlag(Keys.Shift))
                    {
                        pictureBox1.Top += 20;
                    }
                    pictureBox1.Top += 1;
                }
                xtime = 0;
            }
           
        }
        int xtime = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            xtime = 1;
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            chooseimg();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            pictureboxhide = true;
            pictureBox1.Hide();
        }

        PictureBox[] piccol = new PictureBox[0];
        Point[] loclist = new Point[0];
        int[] downlist = new int[0];
        int selectedbox = -1;
        ImageList imgList = new ImageList();
        void chooseimg()
        {
            
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == DialogResult.Cancel) return;
            //add 1 box
            PictureBox[] piccol2 = new PictureBox[piccol.Length+1];
            int[] downist2 = new int[downlist.Length + 1];
            downlist = downist2;
            Point[] loclist2 = new Point[loclist.Length + 1];
            loclist = loclist2;
            int x = 0;
                foreach(PictureBox pic in piccol)
                {
                    piccol2[x++] = pic;
                }
                piccol = piccol2;
            //end
            int len = piccol.Length - 1;

            piccol[len] = new PictureBox();
            piccol[len].ImageLocation = of.FileName;
            piccol[len].Width = 500;
            piccol[len].LoadCompleted += new AsyncCompletedEventHandler((object sender,AsyncCompletedEventArgs e) => {
                piccol[len].Width = piccol[len].Image.Width;
                piccol[len].Height = piccol[len].Image.Height;
                piccol[len].Location = new Point((this.Width / 2) - piccol[len].Width / 2, (this.Height / 2)-piccol[len].Height / 2);
            });
            piccol[len].DoubleClick += new System.EventHandler((object sender, EventArgs e) => {
                //remove
                Controls.Remove(piccol[len]);
                piccol[len] = null;
                //end
            });
            piccol[len].MouseDown += new MouseEventHandler((object sender, MouseEventArgs e) => {
           

                piccol[len].BringToFront();

               
            });

            piccol[len].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            piccol[len].MouseDown += new MouseEventHandler((object sender, MouseEventArgs e) => {
                try { downlist[len] = 1; } catch { }
                selectedbox = len;
            });

            piccol[len].MouseUp += new MouseEventHandler((object sender, MouseEventArgs e) => {
                try { downlist[len] = 0; } catch { }
            });
            piccol[len].MouseMove += new MouseEventHandler((object sender, MouseEventArgs e) => {
                if (downlist[len] == 1)
                {
                    int offsetx = e.X - loclist[len].X;
                    int offsety = e.Y - loclist[len].Y;
                    xxe.X = piccol[len].Left+ offsetx;
                    xxe.Y = piccol[len].Top + offsety;
                    locationid = len;
                }
                else
                {
                    loclist[len] = e.Location;
                }
            });
            selectedbox = len;
            Controls.Add(piccol[len]);
            piccol[len].BringToFront();
            piccol[len].BackColor = Color.Transparent;

            this.UpdateZOrder();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           if( e.Button == MouseButtons.Right)
            {
                label1.Left = (Width / 2) - (label1.Width / 2);
                label1.Top = (Height/ 2) - (label1.Height / 2);
                label1.BringToFront();
                label1.Show();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Hide();
            timer2.Stop();
        }

        Point xxe = new Point(0, 0);
        int locationid = -1;
        private void locatint_Tick(object sender, EventArgs e)
        {
            try{
                if (locationid != -1 && downlist[locationid] == 1)
                {
                    piccol[locationid].Location = xxe;
                    locationid = -1;
                }
            }
            catch (Exception h){ MessageBox.Show(h.Message); }
        }
    }
}
