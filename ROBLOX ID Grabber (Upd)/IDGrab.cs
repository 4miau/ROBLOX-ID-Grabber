using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace RBLXGrabber
{
    class IDGrab
    {

        [STAThread]
        public static void Main(string[] args)
        {
            Console.WriteLine("Created by miau#0004 (https://discord.gg/vSupAKx)");
            Console.WriteLine("Input a ROBLOX URL (Catalog, audio, user, etc). Type 'exit' at any time to close the program.");
            newid:
            string ID = Console.ReadLine();
            switch (ID)
            {
                case "exit":
                    break;
                default:
                    audiograb(ID);
                    goto newid;
            }
        }

        public static string audiograb(string audiolink)
        {
            int slashcount = 0;
            int lastcount = 0;
            int indexer = 0;
            if (!audiolink.Contains("/") || !audiolink.Contains("roblox.com"))
            {
                errorthrow();
                goto errorreturn;
            }
            for (var i = audiolink.Length - 1; i >= 0; i--)
            {
                if (audiolink[i] == '/' && slashcount == 1)
                {
                    lastcount = i;
                    break;
                }
                if (audiolink[i] == '/' && slashcount < 1)
                {
                    slashcount += 1;
                    indexer = i;
                }
            }
                audiolink = audiolink.Substring(lastcount+1, (indexer - lastcount-1));
            try
            {
                var audiolinknumcheck = Convert.ToInt64(audiolink);

                if (long.TryParse(audiolink, out audiolinknumcheck) == true )
                {
                    goto success;
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                goto errorreturn;
            }
        success:
            Console.WriteLine(audiolink);

        errorreturn:
            return audiolink;
        }

        public static void errorthrow()
        {
          Console.WriteLine("This is not a valid ROBLOX link, try again.");
        }

    }
}