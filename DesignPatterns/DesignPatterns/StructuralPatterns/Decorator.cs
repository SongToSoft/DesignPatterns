using System;
using System.Collections.Generic;

namespace DesignPatterns.StructuralPatterns
{
    static class Decorator
    {
        abstract class Component
        {
            abstract public void Execute();
        }

        class AudioComponent : Component
        {
            public override void Execute()
            {
                Console.WriteLine("Execute Audio Component");
            }
        }

        class VideoComponent : Component
        {
            public override void Execute()
            {
                Console.WriteLine("Execute Video Component");
            }
        }

        abstract class MediaDecorator
        {
            public List<Component> components = new List<Component>();

            public void Execute()
            {
                for (int i = 0; i < components.Count; ++i)
                {
                    components[i].Execute();
                }
            }
        }

        class AudioRecorder : MediaDecorator
        {
            public AudioRecorder(MediaDecorator mediaDecorator = null)
            {
                if (mediaDecorator != null)
                {
                    components = mediaDecorator.components;
                }
                components.Add(new AudioComponent());
            }
        }

        class VideoRecorder : MediaDecorator
        {
            public VideoRecorder(MediaDecorator mediaDecorator = null)
            {
                if (mediaDecorator != null)
                {
                    components = mediaDecorator.components;
                }
                components.Add(new VideoComponent());
            }
        }

        static public void Run()
        {
            Console.WriteLine("------------Decorator------------");
            MediaDecorator mediaPlayer = new AudioRecorder();
            mediaPlayer.Execute();

            mediaPlayer = new VideoRecorder(mediaPlayer);
            mediaPlayer.Execute();
        }
    }
}
