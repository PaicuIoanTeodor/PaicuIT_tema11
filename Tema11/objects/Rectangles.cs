
using System;
using System.Collections.Generic;
using System.IO;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace OpenTK3_StandardTemplate_WinForms.objects
{
    public class Rectangles
    {
        private List<Vector3> vertices;
        private List<Vector4> colors;

        public Rectangles()
        {
            vertices = new List<Vector3>();
            colors = new List<Vector4>();
            LoadCubeData(@"..\..\cube_data.txt");
        }

        
        private void LoadCubeData(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');

                        // Citim coordonatele X, Y, Z
                        float x = float.Parse(parts[0]);
                        float y = float.Parse(parts[1]);
                        float z = float.Parse(parts[2]);

                        // Citim culoarea R, G, B, A
                        float r = float.Parse(parts[3]);
                        float g = float.Parse(parts[4]);
                        float b = float.Parse(parts[5]);
                        float a = float.Parse(parts[6]);

                        vertices.Add(new Vector3(x, y, z));
                        colors.Add(new Vector4(r, g, b, a)); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la citirea fișierului de date: " + ex.Message);
            }
        }

        
        public void Draw(bool isTextured, float alpha)
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha); 

            GL.Begin(PrimitiveType.Quads);

            
            if (isTextured)
            {
                // Fața frontală
                DrawFaceT(0, 1, 2, 3); 

                // Fața din spate
                DrawFaceT(4, 5, 6, 7); 

                // Fața superioară
                DrawFaceT(3, 2, 6, 7); 

                // Fața inferioară
                DrawFaceT(0, 1, 5, 4); 

                // Fața stângă
                DrawFaceT(0, 3, 7, 4); 

                // Fața dreaptă
                DrawFaceT(1, 2, 6, 5); 
            }
            else
            {
               
                DrawFace(0, 1, 2, 3, alpha); // Fața frontală
                DrawFace(4, 5, 6, 7, alpha); // Fața din spate
                DrawFace(3, 2, 6, 7, alpha); // Fața superioară
                DrawFace(0, 1, 5, 4, alpha); // Fața inferioară
                DrawFace(0, 3, 7, 4, alpha); // Fața stângă
                DrawFace(1, 2, 6, 5, alpha); // Fața dreaptă
            }

            GL.End();
            GL.Disable(EnableCap.Blend);
        }


        
        private void DrawFace(int v1, int v2, int v3, int v4, float alpha)
        {
           
            GL.Color4(colors[v1].X, colors[v1].Y, colors[v1].Z, alpha);
            GL.Vertex3(vertices[v1]);

            GL.Color4(colors[v2].X, colors[v2].Y, colors[v2].Z, alpha);
            GL.Vertex3(vertices[v2]);

            GL.Color4(colors[v3].X, colors[v3].Y, colors[v3].Z, alpha);
            GL.Vertex3(vertices[v3]);

            GL.Color4(colors[v4].X, colors[v4].Y, colors[v4].Z, alpha);
            GL.Vertex3(vertices[v4]);
        }



       
        private void DrawFaceT(int v1, int v2, int v3, int v4)
        {
           
            Vector2[] texCoords = new Vector2[]
            {
        new Vector2(0.0f, 0.0f), // Vârf 1
        new Vector2(1.0f, 0.0f), // Vârf 2
        new Vector2(1.0f, 1.0f), // Vârf 3
        new Vector2(0.0f, 1.0f)  // Vârf 4
            };

            
            GL.TexCoord2(texCoords[0]);
            GL.Color4(colors[v1].X, colors[v1].Y, colors[v1].Z, colors[v1].W);
            GL.Vertex3(vertices[v1]);

            GL.TexCoord2(texCoords[1]);
            GL.Color4(colors[v2].X, colors[v2].Y, colors[v2].Z, colors[v2].W);
            GL.Vertex3(vertices[v2]);

            GL.TexCoord2(texCoords[2]);
            GL.Color4(colors[v3].X, colors[v3].Y, colors[v3].Z, colors[v3].W);
            GL.Vertex3(vertices[v3]);

            GL.TexCoord2(texCoords[3]);
            GL.Color4(colors[v4].X, colors[v4].Y, colors[v4].Z, colors[v4].W);
            GL.Vertex3(vertices[v4]);
        }


       
        public void Scale(float factor)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i] *= factor;
            }
        }
    }
}