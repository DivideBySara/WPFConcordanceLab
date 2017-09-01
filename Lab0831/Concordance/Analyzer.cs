using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Lab0830
{
    internal struct Wordref
    {
        internal string word;
        internal int paragraphIndex;
        internal int sentenceIndex;
    }

    internal struct Paragraph
    {
        internal string text;
        internal List<Sentence> sentences;

    }

    internal struct Sentence
    {
        internal string text;
        internal List<Wordref> words;
    }

    public class Analyzer
    {
        List<Paragraph> paragraphs = new List<Paragraph>();

        public void Analyze(string input)
        {
            SplitParagraphs(input);
        }

        // Find the paragraphs in the input
        void SplitParagraphs(string @in)
        {
            string[] paragraphStrings;

            Regex reg = new Regex("\r\n");
            paragraphStrings = reg.Split(@in);
            foreach (string pgstr in paragraphStrings)
            {
                if (pgstr != string.Empty)
                {
                    paragraphs.Add(new Paragraph { text = pgstr, sentences = new List<Sentence>() });
                    SplitSentences(paragraphs[paragraphs.Count - 1], paragraphs.Count - 1);
                }
            }
        }

        // Find the sentences in a paragraph
        void SplitSentences(Paragraph pg,int pgindex)
        {
            {
                string[] sentenceStrings;

                Regex reg = new Regex(@"[\.?!]");
                sentenceStrings = reg.Split(pg.text);
                foreach (string sent in sentenceStrings)
                {
                    pg.sentences.Add(new Sentence
                    { text = sent, words = new List<Wordref>() });
                    SplitWords(pg.sentences[pg.sentences.Count - 1],pgindex, pg.sentences.Count - 1);
                }
            }
        }

        // Find the words in each sentence
        void SplitWords(Sentence sent, int pgindex, int sentindex)
        {
            string[] wordStrings;

            Regex reg = new Regex(@"[\s+]");
            Regex reg2 = new Regex(@"\W");
            wordStrings = reg.Split(sent.text);
            foreach (string wd in wordStrings)
            {
                sent.words.Add(new Wordref
                {
                    word = reg2.Replace(wd, "").ToLower(),
                    paragraphIndex = pgindex,
                    sentenceIndex = sentindex
                });
            }
        }

    }
}