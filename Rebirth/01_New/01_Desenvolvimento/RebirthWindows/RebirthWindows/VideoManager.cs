using System;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;

namespace Rebirth {
    public class VideoManager {
         
        public enum VideoID{
            intro
        }


        private ContentManager Content;
        public Video[] videos;

        public VideoManager(ContentManager cm){
            videos = new Video[Enum.GetNames(typeof(VideoID)).Length];
            Content = cm;
        }

        public bool isLoaded(VideoID id){
            return videos[(int)id] != null;
        }

        public Video load(VideoID id){
            switch(id){
                case VideoID.intro:
                    //videos[(int)id] = Content.Load<Video>("Video/intro");
                    break;
            }
            return videos[(int)id];
        }

        public void unLoad(VideoID id){
            videos[(int)id].Dispose();
            videos[(int)id] = null;
        }

    }
}
