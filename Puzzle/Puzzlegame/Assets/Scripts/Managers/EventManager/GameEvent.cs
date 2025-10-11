using Unity.VisualScripting;

public class GameEvent
{
    public static class Global
    {
        public static string SceneChange = "Global.SceneChange";
    }
    public static class H1
    {
        public static class SceneChange
        {
            public static string Clicked = "H1.SceneChange.Clicked";
        }
    }

    public static class H2
    {
        public static class SceneChange
        {
            public static string Clicked = "H2.SceneChange.Clicked";
        }

        public static class Prop
        {
            public static string Clicked = "H2.Prop.Clicked";
        }
    }

    public static class H2A
    {
        public static class SceneChange
        {
            public static string Clicked = "H2A.SceneChange.Clicked";
        }
    }

    public static class H3
    {
        public static class SceneChange
        {
            public static string Clicked = "H3.SceneChange.Clicked";
        }
    }

    public static class H4
    {
        public static class SceneChange
        {
            public static string Clicked = "H4.SceneChange.Clicked";
        }
    }
}
