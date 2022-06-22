using System;

namespace Murgn
{
    public static class EventManager
	{
        public static Action<int, int> DoMapGenerate;
        public static Action<int, int> OnMapGenerate;
        public static Action<float, float, float> DoScreenShake;
        
        public static Action<int, int> SetPlayerPosition;
        public static Action EnablePlayer;
        public static Action DisablePlayer;

        public static Action DoMapReset;
        public static Action DoMapResetWalls;
        public static Action DoMapRead;
        public static Action DoMapResetAndRead;
        public static Action DoMapClipboardCopy;
        public static Action<string> DoMapClipboardRead;
        public static Action GenerateWalls;

        public static Action OnGoButtonPress;

    }   
}