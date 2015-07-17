namespace PlazaSmash.Controllers
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;

    public static class AudioController
    {
        public static SoundEffectInstance MenuMusicInstance { get; private set; }
        
        public static SoundEffectInstance MenuClickInstance { get; private set; }
        
        public static SoundEffectInstance IntroSongInstance { get; private set; }
        
        public static SoundEffectInstance BattleSongInstance { get; private set; }
        
        public static SoundEffectInstance NarratorFightSoundInstance { get; private set; }

        public static SoundEffectInstance ClarkPunchInstance { get; private set; }
        
        public static SoundEffectInstance YuriPunchInstance { get; private set; }
        
        public static SoundEffectInstance YuriKickInstance { get; set; }

        public static SoundEffectInstance ClarkKickInstance { get; private set; }

        public static SoundEffectInstance BlockSoundInstance { get; private set; }
        
        private static SoundEffect MenuClick { get; set; }
        
        private static SoundEffect MenuMusic { get; set; }
        
        private static SoundEffect IntroSong { get; set; }

        private static SoundEffect BattleSong { get; set; }

        private static SoundEffect NarratorFightSound { get; set; }

        private static SoundEffect ClarkPunch { get; set; }

        private static SoundEffect YuriPunch { get; set; }

        private static SoundEffect YuriKick { get; set; }

        private static SoundEffect ClarkKick { get; set; }

        private static SoundEffect BlockSound { get; set; }

        public static void Initialize()
        {
            MenuMusic = EntryPoint.Game.Content.Load<SoundEffect>("Menu\\MenuMusic");
            MenuMusicInstance = MenuMusic.CreateInstance();
            MenuMusicInstance.Volume = 0.3f;
            MenuMusicInstance.Pitch = -0.1f;

            MenuClick = EntryPoint.Game.Content.Load<SoundEffect>("Menu\\MenuClick");
            MenuClickInstance = MenuClick.CreateInstance();
            MenuClickInstance.Volume = 1;
            MenuClickInstance.Pitch = 0.3f;

            IntroSong = EntryPoint.Game.Content.Load<SoundEffect>("Intro\\IntroWav");
            IntroSongInstance = IntroSong.CreateInstance();
            IntroSongInstance.Volume = 0.8f;

            BattleSong = EntryPoint.Game.Content.Load<SoundEffect>("IngameAudio\\BattleSong");
            BattleSongInstance = BattleSong.CreateInstance();
            BattleSongInstance.Volume = 0.05f;

            NarratorFightSound = EntryPoint.Game.Content.Load<SoundEffect>("IngameAudio\\Fight");
            NarratorFightSoundInstance = NarratorFightSound.CreateInstance();

            ClarkPunch = EntryPoint.Game.Content.Load<SoundEffect>("IngameAudio\\ClarkPunch");
            ClarkPunchInstance = ClarkPunch.CreateInstance();

            YuriPunch = EntryPoint.Game.Content.Load<SoundEffect>("IngameAudio\\YuriPunch");
            YuriPunchInstance = YuriPunch.CreateInstance();

            YuriKick = EntryPoint.Game.Content.Load<SoundEffect>("IngameAudio\\YuriKick");
            YuriKickInstance = YuriKick.CreateInstance();

            ClarkKick = EntryPoint.Game.Content.Load<SoundEffect>("IngameAudio\\ClarkKick");
            ClarkKickInstance = ClarkKick.CreateInstance();

            BlockSound = EntryPoint.Game.Content.Load<SoundEffect>("IngameAudio\\Block");
            BlockSoundInstance = BlockSound.CreateInstance();   
        }

        public static void PlaySound(SoundEffectInstance instance)
        {
            instance.Play();
        }

        public static void StopSound(SoundEffectInstance instance)
        {
            instance.Stop();
        }

        public static void PauseSound(SoundEffectInstance instance)
        {
            instance.Pause();
        }

        public static void ResumeSound(SoundEffectInstance instance)
        {
            instance.Resume();
        }
    }
}
