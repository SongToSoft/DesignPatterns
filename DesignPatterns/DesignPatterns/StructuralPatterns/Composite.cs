using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralPatterns
{
    static class Composite
    {
        //Component
        abstract class FileSystemObject
        {
            protected string name;

            public FileSystemObject(string name)
            {
                this.name = name;
            }

            public abstract void Display();
            public abstract void Add(FileSystemObject c);
            public abstract void Remove(FileSystemObject c);
        }

        //Composite
        class Directory : FileSystemObject
        {
            List<FileSystemObject> files = new List<FileSystemObject>();

            public Directory(string name)
                : base(name)
            { }

            public override void Add(FileSystemObject file)
            {
                files.Add(file);
            }

            public override void Remove(FileSystemObject file)
            {
                files.Remove(file);
            }

            public override void Display()
            {
                Console.WriteLine(name);

                foreach (FileSystemObject file in files)
                {
                    file.Display();
                }
            }
        }

        //Leaf
        class File : FileSystemObject
        {
            public File(string name)
                : base(name)
            { }

            public override void Display()
            {
                Console.WriteLine(name);
            }

            public override void Add(FileSystemObject file)
            {
                throw new NotImplementedException();
            }

            public override void Remove(FileSystemObject file)
            {
                throw new NotImplementedException();
            }
        }

        static public void Run()
        {
            Console.WriteLine("------------Composite------------");
            Directory documents = new Directory("Documents");
            Directory video = new Directory("Video");
            Directory images = new Directory("Images");
            documents.Add(video);
            documents.Add(images);
            File videoOne = new File("video one.mkv");
            File videoTwo = new File("video two.mkv");
            File image = new File("image.jpg");

            video.Add(videoOne);
            video.Add(videoTwo);
            images.Add(image);

            documents.Display();
        }
    }
}
