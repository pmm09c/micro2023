using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LLama;
using LLama.Common;


public class llamatest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string modelPath = "<Your model path>";
        string prompt = "what is your purpose?";
        // Initialize a chat session
        var ex = new InteractiveExecutor(new LLamaModel(new ModelParams(modelPath, contextSize: 1024, seed: 1337)));
        ChatSession session = new ChatSession(ex);

        // show the prompt
        Debug.Log(prompt);

        // run the inference in a loop to chat with LLM
        while (prompt != "stop")
        {
            foreach (var text in session.Chat(prompt, new InferenceParams() { Temperature = 0.6f, AntiPrompts = new List<string> { "User:" } }))
            {
                Debug.Log(text);
            }

            prompt = "stop";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
