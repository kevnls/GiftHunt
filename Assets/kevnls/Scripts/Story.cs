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
        private static int phraseCounter = 0;

        void Start()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(storyXML.text);
            XmlNodeReader reader = new XmlNodeReader(xmlDoc);
            storyContainer = StoryContainer.Load(reader);

            //start at a random point in the phrase sequence
            phraseCounter = Random.Range(0, storyContainer.phrases.Length);
        }

        public static string GetPhrase()
        {
            string returnString = string.Empty;

            //get phrases sequentially
            returnString = storyContainer.phrases[phraseCounter].phrase;
            phraseCounter++;

            if (phraseCounter >= storyContainer.phrases.Length)
            {
                phraseCounter = 0;
            }

            //get phrases randomly
            //int intRandom = Random.Range(0, storyContainer.phrases.Length);
            //returnString = storyContainer.phrases[intRandom].phrase;

            return returnString;
        }

        public static string GetNextParagraph()
        {
            string returnString = string.Empty;

            //gets paragraphs sequentially
            if (paragraphCounter < storyContainer.paragraphs.Length)
            {
                returnString = storyContainer.paragraphs[paragraphCounter].paragraph;
                paragraphCounter++;
            }
            else
            {
                //if we've reached the end of the paragraphs the story is over 
                returnString = string.Empty;
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
