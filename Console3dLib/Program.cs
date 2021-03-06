﻿using Console3dLib.CoreTypes;
using Console3dLib.CoreTypes.DrawingTypes;
using Console3dLib.CoreTypes.Interfaces;
using Console3dLib.CoreTypes.WorldTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib
{
    public class TestObj : IDrawable
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Scalar { get; set; }
        public Triangle[] Triangles { get; set; }
        public Dictionary<int,Vector4> UVMapping { get; set; }
        public Texture UVTexture { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            

            #region ComponentTests
            /*
            //World world = new World();
            Matrix a = new Matrix(new float[,] {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f},
                { 0f, 0f, 1f, 0f},
                { 0f, 0f, 0f, 1f}
            });


            Matrix scale = Matrix.IdentityMatrix;

            Matrix b = Matrix.FromVector3(new Vector3(10, 0, 0));

            Matrix rot = Quaternion.ToRotationMatrix(Quaternion.FromEulerAngles(new Vector3(0,0,(float)Math.PI/2f)));

            Matrix c = a * b;
            //MatrixDisplay(rot);

            //MatrixDisplay(Matrix.FromVector3(Quaternion.ToEulerAngles(Quaternion.FromEulerAngles(new Vector3(0, (float)Math.PI / 2f, 0)))));

            //MatrixDisplay(Matrix.FromVector4(Quaternion.FromEulerAngles(new Vector3(0, (float)Math.PI/2, 0)).Values));
            MatrixDisplay(b);
            Camera cam = new Camera(70, 4 / 3, 0.1f, 10);
            MatrixDisplay(cam.ProjectionMatrix*b);
            MatrixDisplay(cam.ProjectionMatrix*Matrix.FromVector3(new Vector3(0,0,10)));
            //MatrixDisplay(Matrix.RoundValues(rot*b,-3));
            Console.Write("\n\n\n");

            for(int i = 0; i < 16; i++)
            {
                Console.ForegroundColor = (ConsoleColor)i;
                Console.Write(((ConsoleColor)i).ToString() + "███ ");
            }
            */
            #endregion

            while(!Console.KeyAvailable)
            {

            }
            if (Console.ReadKey(true).KeyChar == 't')
            {
                Texture t = new Texture();
                t.LoadFromFile(@"C:\Users\Peter Husman\Documents\GitHub\Console3DLib\Console3dLib\TestTexture.png");
                ;

                for (int y = 0; y < t.Height; y++)
                {
                    for (int x = 0; x < Console.BufferWidth; x++)
                    {
                        Console.BackgroundColor = t[x, y].NearestConsoleColor();
                        Console.Write(" ");
                    }
                    Console.Write("/n");
                }

                while (true)
                {

                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Camera cam = new Camera(90, 1080f / 1920f * 4f/5f, 0.01f, 100);
                cam.Position = new Vector3(0, 0, -1f);
                cam.Rotation = Quaternion.FromEulerAngles(Vector3.One * 0);
                cam.UpdateViewMatrix();
                TestObj[] obj = new TestObj[1];
                obj[0] = new TestObj();
                obj[0].Position = new Vector3(0, 0, 0);
                obj[0].Rotation = Quaternion.FromEulerAngles(new Vector3(0, 0, 0));
                obj[0].Scalar = Vector3.One * 100;
                obj[0].Triangles = new Triangle[] { new Triangle(new Vertex[] { new Vertex(1f, 1f, 1f), new Vertex(-1f, 1f, 1f), new Vertex(1f, -1f, 1f) }), new Triangle(new Vertex[] { new Vertex(1f, 1f, -1f), new Vertex(1f, 1f, 1f), new Vertex(-1f, 1f, -1f) }), new Triangle(new Vertex[]{ new Vertex(1f, 1f, -1f), new Vertex(-1f, 1f, -1f), new Vertex(1f, -1f, -1f) }), new Triangle(new Vertex[]{ new Vertex(1f, 1f, -1f), new Vertex(1f, 1f, 1f), new Vertex(-1f, 1f, -1f) }) };



                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKey c = Console.ReadKey(true).Key;
                        if (c == ConsoleKey.W)
                        {
                            obj[0].Rotation = new Quaternion(obj[0].Rotation.Values + Quaternion.FromEulerAngles(new Vector3((float)Math.PI / 8f, 0, 0)).Values);
                        }
                        if (c == ConsoleKey.A)
                        {
                            obj[0].Rotation = new Quaternion(obj[0].Rotation.Values + Quaternion.FromEulerAngles(new Vector3(0, (float)Math.PI / 8f, 0)).Values);
                        }
                        if (c == ConsoleKey.S)
                        {
                            obj[0].Rotation = new Quaternion(obj[0].Rotation.Values + Quaternion.FromEulerAngles(new Vector3(-(float)Math.PI / 8f, 0, 0)).Values);
                        }
                        if (c == ConsoleKey.D)
                        {
                            obj[0].Rotation = new Quaternion(obj[0].Rotation.Values + Quaternion.FromEulerAngles(new Vector3(0, -(float)Math.PI / 8f, 0)).Values);
                        }
                        if (c == ConsoleKey.R)
                        {
                            obj[0].Rotation = new Quaternion(obj[0].Rotation.Values + Quaternion.FromEulerAngles(new Vector3(0, 0, -(float)Math.PI / 8f)).Values);
                        }
                        if (c == ConsoleKey.F)
                        {
                            obj[0].Rotation = new Quaternion(obj[0].Rotation.Values + Quaternion.FromEulerAngles(new Vector3(0, 0, (float)Math.PI / 8f)).Values);
                        }
                        if (c == ConsoleKey.RightArrow)
                        {
                            cam.Position += Vector3.Forward;
                        }
                        if (c == ConsoleKey.LeftArrow)
                        {
                            cam.Position -= Vector3.Forward;
                        }
                        if (c == ConsoleKey.UpArrow)
                        {
                            cam.Position += Vector3.Side;
                        }
                        if (c == ConsoleKey.DownArrow)
                        {
                            cam.Position -= Vector3.Side;
                        }
                        if (c == ConsoleKey.NumPad3)
                        {
                            cam.Rotation = new Quaternion(cam.Rotation.Values + Quaternion.FromEulerAngles(new Vector3(0, -(float)Math.PI / 8f, 0)).Values);
                        }
                        if (c == ConsoleKey.NumPad1)
                        {
                            cam.Rotation = new Quaternion(cam.Rotation.Values + Quaternion.FromEulerAngles(new Vector3(0, (float)Math.PI / 8f, 0)).Values);
                        }
                        if (c == ConsoleKey.NumPad4)
                        {
                            cam.Position += new Vector3(1f, 0, 0);
                        }
                        if (c == ConsoleKey.NumPad6)
                        {
                            cam.Position -= new Vector3(1f, 0, 0);
                        }
                        if (c == ConsoleKey.NumPad8)
                        {
                            cam.Position += new Vector3(0f, 1, 0);
                        }
                        if (c == ConsoleKey.NumPad5)
                        {
                            cam.Position -= new Vector3(0, 1, 0);
                        }

                        cam.UpdateViewMatrix();
                    }
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);

                    }

                    Console.Clear();
                    cam.Render(obj);
                    System.Threading.Thread.Sleep(100);
                }
            }


        }

        private static void MatrixDisplay(Matrix a)
        {
            for (int y = 0; y < a.Rows; y++)
            {
                for (int x = 0; x < a.Columns; x++)
                {
                    Console.Write(a[y, x].ToString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
