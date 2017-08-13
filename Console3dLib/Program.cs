﻿using Console3dLib.CoreTypes;
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
        public Vertex[] Vertices { get; set; }

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


            Camera cam = new Camera(60,4/3,0,100);
            cam.Position = new Vector3(0,0,0);
            cam.Rotation = Quaternion.FromEulerAngles(Vector3.One * 0);
            cam.UpdateViewMatrix();
            TestObj[] obj = new TestObj[1];
            obj[0] = new TestObj();
            obj[0].Position = new Vector3(0, 0, 0);
            obj[0].Rotation = Quaternion.FromEulerAngles(new Vector3(0,0,0));
            obj[0].Scalar = Vector3.One;
            obj[0].Vertices = new Vertex[] { new Vertex(10,0,10), new Vertex(20,0,0), new Vertex(0,10,10) };

            

            while(true)
            {
                if(Console.KeyAvailable)
                {
                    char c = Console.ReadKey(true).KeyChar;
                    if(c == 'w')
                    {
                        obj[0].Rotation = new Quaternion(obj[0].Rotation.Values + Quaternion.FromEulerAngles(new Vector3(10, 0, 0)).Values);
                    }
                    if (c == 'a')
                    {
                        obj[0].Rotation = new Quaternion(obj[0].Rotation.Values + Quaternion.FromEulerAngles(new Vector3(0, 10, 0)).Values);
                    }
                    if (c == 's')
                    {
                        obj[0].Rotation = new Quaternion(obj[0].Rotation.Values + Quaternion.FromEulerAngles(new Vector3(-10, 0, 0)).Values);
                    }
                    if (c == 'd')
                    {
                        obj[0].Rotation = new Quaternion(obj[0].Rotation.Values + Quaternion.FromEulerAngles(new Vector3(0, -10, 0)).Values);
                    }
                }
                //Console.Clear();
                cam.Render(obj);
            }

            Console.ReadKey();



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
