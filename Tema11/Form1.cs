using System;
using System.Drawing;
using System.Windows.Forms;

using OpenTK.Graphics.OpenGL;

using OpenTK3_StandardTemplate_WinForms.helpers;
using OpenTK3_StandardTemplate_WinForms.objects;

namespace OpenTK3_StandardTemplate_WinForms
{
    public partial class MainForm : Form
    {
        private Axes mainAxis;
        private Rectangles re;
        private Camera cam;
        private Scene scene;
        private System.Windows.Forms.Button toggleAlphaBlendingButton;


        private Point mousePosition;

        public MainForm()
        {
          
            InitializeComponent();

            
            scene = new Scene();

            scene.GetViewport().Load += new EventHandler(this.mainViewport_Load);
            scene.GetViewport().Paint += new PaintEventHandler(this.mainViewport_Paint);
            scene.GetViewport().MouseMove += new MouseEventHandler(this.mainViewport_MouseMove);

            this.Controls.Add(scene.GetViewport());


            this.toggleAlphaBlendingButton = new System.Windows.Forms.Button();
            this.toggleAlphaBlendingButton.Text = "Toggle Alpha Blending";
            this.toggleAlphaBlendingButton.Location = new System.Drawing.Point(200, 10);
            this.toggleAlphaBlendingButton.Size = new System.Drawing.Size(150, 30);
            this.toggleAlphaBlendingButton.Click += new System.EventHandler(this.toggleAlphaBlendingButton_Click);
            this.Controls.Add(this.toggleAlphaBlendingButton);



        }


        private bool isAlphaBlendingEnabled = false;

        private void toggleAlphaBlendingButton_Click(object sender, EventArgs e)
        {
            isAlphaBlendingEnabled = !isAlphaBlendingEnabled;

            if (isAlphaBlendingEnabled)
            {
                GL.Enable(EnableCap.Blend);
                GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);  // Formula pentru alpha blending
            }
            else
            {
                GL.Disable(EnableCap.Blend);
            }

            scene.Invalidate();
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeAnimationTimer();
            
            Randomizer.Init();

            
            cam = new Camera(scene.GetViewport());
            this.Size = new Size(1124, 768);
           
            mainAxis = new Axes(showAxes.Checked);
            re = new Rectangles();

            re.Scale(5.0f); 
            scene.Invalidate(); 


        }

        private void showAxes_CheckedChanged(object sender, EventArgs e)
        {
            mainAxis.SetVisibility(showAxes.Checked);

            scene.Invalidate();
        }

        private void changeBackground_Click(object sender, EventArgs e)
        {
            GL.ClearColor(Randomizer.GetRandomColor());

            scene.Invalidate();
        }

        private void resetScene_Click(object sender, EventArgs e)
        {
            showAxes.Checked = true;
            mainAxis.SetVisibility(showAxes.Checked);
            scene.Reset();
            cam.Reset();
            isTextureEnabled = false;
            isLightingEnabled = false;
            isAlphaBlendingEnabled = false;
            scene.Invalidate();
        }

        private void mainViewport_Load(object sender, EventArgs e)
        {
            scene.Reset();
        }

        private void mainViewport_MouseMove(object sender, MouseEventArgs e)
        {
            mousePosition = new Point(e.X, e.Y);
            scene.Invalidate();
        }

        private bool isLightingEnabled = false;
        private bool isTextureEnabled = false;
        private int textureId;

        private bool isMoving = false;  
        private float zPosition = 0f;   
        private float targetZPosition = 10f;  
        private Timer animationTimer;   
        private const float movementSpeed = 0.1f; 


        private void toggleLightingButton_Click(object sender, EventArgs e)
        {
            isLightingEnabled = !isLightingEnabled;
            if (isLightingEnabled)
            {
                GL.ClearColor(0f, 0f, 0f, 1f); 

              
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);  
                GL.Enable(EnableCap.Light1);  

              
                float[] lightPosition0 = { 10.0f, 10.0f, 5.0f, 1.0f };
                float[] lightAmbient0 = { 0.0f, 0.0f, 0.9f, 1.0f }; 
                float[] lightDiffuse0 = { 0.0f, 0.0f, 0.9f, 1.0f }; 

                
                float[] lightPosition1 = { 10.0f, 10.0f, 30.0f, 1.0f }; 
                float[] lightAmbient1 = { 0.2f, 0.0f, 0.0f, 1.0f }; 
                float[] lightDiffuse1 = { 0.4f, 0.0f, 0.0f, 1.0f }; 

               
                GL.Light(LightName.Light0, LightParameter.Position, lightPosition0);
                GL.Light(LightName.Light0, LightParameter.Ambient, lightAmbient0);
                GL.Light(LightName.Light0, LightParameter.Diffuse, lightDiffuse0);

               
                GL.Light(LightName.Light1, LightParameter.Position, lightPosition1);
                GL.Light(LightName.Light1, LightParameter.Ambient, lightAmbient1);
                GL.Light(LightName.Light1, LightParameter.Diffuse, lightDiffuse1);
            }
            else
            {
                GL.ClearColor(0.7f, 0.7f, 0.7f, 1f); 
                GL.Disable(EnableCap.Lighting);
                GL.Disable(EnableCap.Light0);  
                GL.Disable(EnableCap.Light1); 
            }
            scene.Invalidate();
        }


        private void applyTextureButton_Click(object sender, EventArgs e)
        {
            isTextureEnabled = !isTextureEnabled;
            textureId = LoadTexture(@"..\..\brickTexture1.jpg");
            scene.Invalidate();
        }

        // Textura PNG
        private int LoadTexture(string filename)
        {
            Bitmap bitmap = new Bitmap(filename);
            int tex;

            GL.GenTextures(1, out tex);
            GL.BindTexture(TextureTarget.Texture2D, tex);

            System.Drawing.Imaging.BitmapData data = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bitmap.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            return tex;
        }

        private void mainViewport_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            cam.SetView();

            if (enableRotation.Checked)
            {
                GL.Rotate(Math.Max(mousePosition.X, mousePosition.Y), 1, 1, 1);
            }

            // Desenează axele fără texturare
            mainAxis.Draw();

            // Desenează primul cub (opac) cu texturare, dacă este activă
            if (isTextureEnabled)
            {
                GL.Enable(EnableCap.Texture2D);
                GL.BindTexture(TextureTarget.Texture2D, textureId);
            }

            GL.PushMatrix();
            GL.Translate(-5, 0, zPosition); 
            re.Draw(isTextureEnabled, 1.0f); 
            GL.PopMatrix();

           
            if (isAlphaBlendingEnabled)
            {
                GL.Enable(EnableCap.Blend);
                GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);  

                GL.PushMatrix();
                GL.Translate(5, 5, zPosition); 
                re.Draw(isTextureEnabled, 0.5f); 
                GL.PopMatrix();

                GL.Disable(EnableCap.Blend);
            }
            else
            {
                GL.PushMatrix();
                GL.Translate(5, 5, zPosition); 
                re.Draw(isTextureEnabled, 1.0f); 
                GL.PopMatrix();
            }

            
            if (isTextureEnabled)
            {
                GL.Disable(EnableCap.Texture2D);
            }

            scene.GetViewport().SwapBuffers();
        }



        private void InitializeAnimationTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 10; 
            animationTimer.Tick += AnimationTimer_Tick;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            
            float step = 0.05f; 
            if (zPosition < targetZPosition)
            {
                zPosition += step; 
                if (zPosition >= targetZPosition)
                {
                    zPosition = targetZPosition;
                    animationTimer.Stop(); 
                    isMoving = false;
                }
            }
            else if (zPosition > targetZPosition)
            {
                zPosition -= step; 
                if (zPosition <= targetZPosition)
                {
                    zPosition = targetZPosition;
                    animationTimer.Stop(); 
                    isMoving = false;
                }
            }

           
            scene.Invalidate(); 
        }

        private void toggleMovementButton_Click(object sender, EventArgs e)
        {
            
            if (isMoving)
            {
                return; // Nu inițiază o altă animație dacă deja se mișcă
            }

            
            if (zPosition == targetZPosition)
            {
                targetZPosition = (targetZPosition == 10f) ? 0f : 10f;
            }

           
            isMoving = true;
            animationTimer.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}