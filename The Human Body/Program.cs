using System;

namespace The_Human_Body
{
    class Program
    {
        static void Main(string[] args)
        {
            Ear ear = new Ear();
            ear.listen = "I can hear you";
            ear.information = "The ear is the organ of hearing and balance.\nThe parts of the ear include:\nExternal or outer ear, consisting of:\nPinna or auricle. \nThis is the outside part of the ear.";
            Eye eye = new Eye();
            eye.see = "I can see you";
            eye.information = "The eye is a sensory organ. \nIt collects light from the visible world around us and converts it into nerve impulses. \nThe optic nerve transmits these signals to the brain, which forms an image so thereby providing sight.";
            Nose nose = new Nose();
            nose.smell = "I smell something delicious";
            Console.WriteLine("the ear");
            Console.WriteLine("-------");
            Console.WriteLine(ear.information);
            Console.WriteLine("\n");
            Console.WriteLine("The boy said: " + ear.listen);
            Console.WriteLine("the eyen");
            Console.WriteLine("-------\n");
            Console.WriteLine(eye.information);
            Console.WriteLine("\n");
            Console.WriteLine("The girl said: " + eye.see);
            Console.WriteLine("the nose");
            Console.WriteLine("-------");
            Console.WriteLine("The guy said: " + nose.smell);
        }
    }
}
