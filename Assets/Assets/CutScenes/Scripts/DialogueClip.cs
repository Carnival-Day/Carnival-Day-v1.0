using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI; // Add this line for Text

[System.Serializable]
public class DialogueClip : PlayableAsset, ITimelineClipAsset
{
    public string dialogueText;

    public ClipCaps clipCaps => ClipCaps.Blending;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DialogueBehaviour>.Create(graph);
        var behaviour = playable.GetBehaviour();
        behaviour.dialogueText = dialogueText;
        return playable;
    }
}

[System.Serializable]
public class DialogueBehaviour : PlayableBehaviour
{
    public string dialogueText;
    private Text textUI;

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        base.OnBehaviourPlay(playable, info);
        // Display dialogue text
        if (textUI == null)
            textUI = GameObject.FindObjectOfType<Text>(); // You should assign a UI Text element to this variable
        textUI.text = dialogueText;
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        base.ProcessFrame(playable, info, playerData);
        // Handle input events
        if (Input.GetMouseButtonDown(0))
        {
            // Scroll through text or trigger next dialogue
            // You can implement your specific logic here
        }
    }
}
