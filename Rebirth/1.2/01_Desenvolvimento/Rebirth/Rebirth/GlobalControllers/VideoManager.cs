using System;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Rebirth {
    public static class VideoManager {
         
        public enum VideoID{
            intro
        }


        private static ContentManager Content;
        public static  Video[] videos;

        public static void initialize(ContentManager cm){
            videos = new Video[Enum.GetNames(typeof(VideoID)).Length];
            Content = cm;
        }

        public static bool isLoaded(VideoID id){
            return videos[(int)id] != null;
        }

        public static Video load(VideoID id){
            switch(id){
                case VideoID.intro:
                    //videos[(int)id] = Content.Load<Video>("Video/intro");
                    break;
            }
            return videos[(int)id];
        }

        public static void unLoad(VideoID id){
            videos[(int)id].Dispose();
            videos[(int)id] = null;
        }

    }
}
