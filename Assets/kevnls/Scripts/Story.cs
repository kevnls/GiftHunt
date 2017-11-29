using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

namespace kevnls
{
    //This is the script that will handle retrieving all 
    //the story data from the story.xml file
    public class Story : MonoBehaviour
    {
        public TextAsset storyXML;
        
        private static StoryContainer storyContainer;
        private static int paragraphCounter = 0;

        void Start()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(storyXML.text);
            XmlNodeReader reader = new XmlNodeReader(xmlDoc);
            storyContainer = StoryContainer.Load(reader);
        }

        //gets a random phrase
        public static string GetPhrase()
        {
            string returnString = "";

            int intRandom = Random.Range(0, storyContainer.phrases.Length);
            returnString = storyContainer.phrases[intRandom].phrase;

            return returnString;
        }

        //gets paragraphs sequentially
        public static string GetNextParagraph()
        {
            string returnString = string.Empty;

            foreach (Paragraph paragraph in storyContainer.paragraphs)
            {
                if (paragraphCounter <= storyContainer.paragraphs.Length)
                {
                    returnString = storyContainer.paragraphs[paragraphCounter].paragraph;
                    paragraphCounter++;
                }
                else
                {
                    //if we've reached the end of the paragraphs return an empty string
                    returnString = string.Empty;
                }
            }

            return returnString;
        }
    }

    [XmlRoot("story")]
    public class StoryContainer
    {
        [XmlAttribute("title")]
        public string title;

        [XmlArray("paragraphs")]
        [XmlArrayItem("paragraph")]
        public Paragraph[] paragraphs;

        [XmlArray("phrases")]
        [XmlArrayItem("phrase")]
        public Phrase[] phrases;

        public static StoryContainer Load(XmlNodeReader reader)
        {
            var serializer = new XmlSerializer(typeof(StoryContainer));
            return serializer.Deserialize(reader) as StoryContainer;
        }
    }

    public class Paragraph
    {
        [XmlText]
        public string paragraph;
    }

    public class Phrase
    {
        [XmlText]
        public string phrase;
    }
}
