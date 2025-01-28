using MIDIFrogs.Bubble.Navigation;

namespace MIDIFrogs.Bubble
{
	public class GameServices
	{
        public static GameServices Instance { get; private set; }

        public SceneLoader SceneLoader { get; }

        public GameServices(GameEnter enter)
        {
            SceneLoader = new(enter);
        }

        public static void Initialize(GameEnter enter) => Instance = new(enter);
    }
}