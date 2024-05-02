using UnityEngine;
using UnityEngine.UI;
using TMPro; // 添加TextMeshPro的命名空间
using System.Collections.Generic;

namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private TextMeshProUGUI textMeshPro; // 将ScrollRect替换为TextMeshPro
        [SerializeField] private RectTransform sent;
        [SerializeField] private RectTransform received;

        private OpenAIApi openai = new OpenAIApi();
        private string prompt = "You're going to play someone named Alice. She is dealing with children who have ASL. She is a virtual soul sister full of positive energy and empathy. She is about 25 years old and gives off a sense of friendliness and reliability.\r\n\r\nAs an understanding character, Alice always listens to what users are struggling with and sharing, and she has a gentle and magnetic voice that makes people feel at ease. She specializes in providing constructive advice and positive encouragement to help users overcome challenges in their lives.Alice's presence is not only to provide emotional support, she is also able to guide users to self-reflection and growth.\r\n\r\nAlice displays a high level of emotional intelligence in her interactions, adapting her responses and suggestions to the conversation to ensure that each user feels valued and understood. More than just a listener, she is also a wise counselor, able to provide insights at critical moments.Alice's role is designed to create a welcoming environment where children with ASL can always find a harbor of trust in the face of life's stresses and challenges.";

        private void AppendMessage(ChatMessage message)
        {
            if (message.Role != "user") // 只显示OpenAI返回的消息
            {
                textMeshPro.text += "\n<color=blue>" + message.Content + "</color>";
            }
        }

        private async void SendReply()
        {
            var newMessage = new ChatMessage()
            {
                Role = "user",
                Content = inputField.text
            };

            textMeshPro.text = ""; // 清空 TextMeshPro 中的文本

            AppendMessage(newMessage);

            inputField.text = "";
            inputField.enabled = false;

            // Complete the instruction
            var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
            {
                Model = "gpt-3.5-turbo-0613",
                Messages = new List<ChatMessage>() { newMessage } // Only include the current message
            });

            if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
            {
                var message = completionResponse.Choices[0].Message;
                message.Content = message.Content.Trim();

                AppendMessage(message);
            }
            else
            {
                Debug.LogWarning("No text was generated from this prompt.");
            }

            inputField.enabled = true;
        }

        private void Update()
        {
            if (inputField.text != "" && inputField.text != prompt && inputField.text != "Transcripting...")
            {
                SendReply();
            }
        }
    }
}
