using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Resources;

namespace Anagrams
{
    public class WAVSounds
    {
        [DllImport("WinMM.dll")]
        public static extern bool PlaySound(byte[] wfname, int fuSound);

        //  flag values for SoundFlags argument on PlaySound
        public int SND_SYNC = 0x0000;      // play synchronously (default)
        public int SND_ASYNC = 0x0001;      // play asynchronously
		public int SND_NODEFAULT = 0x0002;      // silence (!default) if sound not found
        public int SND_MEMORY = 0x0004;      // pszSound points to a memory file
        public int SND_LOOP = 0x0008;      // loop the sound until next sndPlaySound
        public int SND_NOSTOP = 0x0010;      // don't stop any currently playing sound
        public int SND_NOWAIT = 0x00002000; // don't wait if the driver is busy
        public int SND_ALIAS = 0x00010000; // name is a Registry alias
        public int SND_ALIAS_ID = 0x00110000; // alias is a predefined ID
        public int SND_FILENAME = 0x00020000; // name is file name
        public int SND_RESOURCE = 0x00040004; // name is resource name or atom
        public int SND_PURGE = 0x0040;     // purge non-static events for task
        public int SND_APPLICATION = 0x0080;     // look for app-specific association

        ////-----------------------------------------------------------------
        //public void Play(string wfname)
        //{
        //    byte[] bname = new Byte[256];    //Max path length
        //    bname = System.Text.Encoding.ASCII.GetBytes(wfname);
        //    PlaySound(bname, SND_ASYNC | SND_FILENAME);
        //}
        //-----------------------------------------------------------------
        public void Play(string wfname, int SoundFlags)
        {
            byte[] bname = new Byte[256];    //Max path length
            bname = System.Text.Encoding.ASCII.GetBytes(wfname);
            PlaySound(bname, SoundFlags);
        }

        //-----------------------------------------------------------------
        public void StopPlay()
        {
            PlaySound(null, SND_PURGE);
        }

        //public const UInt32 SND_ASYNC = 1;
        //public const UInt32 SND_MEMORY = 4;
        //// these 2 overloads we dont need ...
        //// [DllImport("Winmm.dll")]
        //// public static extern bool PlaySound(IntPtr rsc, IntPtr hMod, UInt32 dwFlags);
        //// [DllImport("Winmm.dll")]
        //// public static extern bool PlaySound(string Sound, IntPtr hMod, UInt32 dwFlags);
        //// this is the overload we want to play embedded resource...
        //[DllImport("Winmm.dll")]
        //public static extern bool PlaySound(byte[] data, IntPtr hMod, UInt32 dwFlags);
        //public Winmm()
        //{
        //}
        //public static void PlayWavResource(string wav)
        //{
        //    // get the namespace
        //    string strNameSpace=
        //    System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString();
        //    // get the resource into a stream
        //    Stream str =
        //    System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream( strNameSpace +"."+ wav );
        //    if ( str == null )
        //        return;
        //    // bring stream into a byte array
        //    byte[] bStr = new Byte[str.Length];
        //    str.Read(bStr, 0, (int)str.Length);
        //    // play the resource
        //    PlaySound(bStr, IntPtr.Zero, SND_ASYNC | SND_MEMORY);
        //}
    
    }
}
