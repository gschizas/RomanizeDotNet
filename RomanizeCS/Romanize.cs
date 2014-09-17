using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanizeCS
{
    public static class Romanize
    {
        const string simpleTranslationGreek = "άβδέζήιίϊΐκλνξόπρσςτυύϋΰφωώ";
        const string simpleTranslationLatin = "avdeziiiiiklnxoprsstyyyyfoo";
        const string digraphTranslationGreek = "θχψ";
        const string digraphTranslationLatin = "thchps";
        const string digraphYpsilonGreek = "αεη";
        const string digraphYpsilonLatin = "aei";
        const string digraphYpsilonBeta = "βγδζλμνραάεέηήιίϊΐοόυύϋΰωώ";
        const string digraphYpsilonPhi = "θκξπστφχψ";

        public static string RomanizeText(string greekText)
        {
            var result = new StringBuilder();
            int cursor = 0;
            string letter, newLetter, previousLetter, nextLetter, thirdLetter;
            bool isUpper, isUpper2;
            while (cursor < greekText.Count())
            {
                letter = greekText.Substring(cursor, 1);
                previousLetter = (cursor > 0) ? greekText.Substring(cursor - 1, 1) : "";
                nextLetter = (cursor < greekText.Count() - 1) ? greekText.Substring(cursor + 1, 1) : "";
                thirdLetter = (cursor < greekText.Count() - 2) ? greekText.Substring(cursor + 2, 1) : "";

                isUpper = (letter.ToUpper() == letter);
                isUpper2 = (nextLetter.ToUpper() == nextLetter);
                letter = letter.ToLower();
                previousLetter = previousLetter.ToLower();
                nextLetter = nextLetter.ToLower();
                thirdLetter = thirdLetter.ToLower();

                if (simpleTranslationGreek.Contains(letter))
                {
                    newLetter = simpleTranslationLatin.Substring(simpleTranslationGreek.IndexOf(letter), 1);
                }
                else if (digraphTranslationGreek.Contains(letter))
                {
                    int diphthong_index = digraphTranslationGreek.IndexOf(letter);
                    newLetter = digraphTranslationLatin.Substring(diphthong_index * 2, 2);
                }
                else if (digraphYpsilonGreek.Contains(letter))
                {
                    newLetter = digraphYpsilonLatin.Substring(digraphYpsilonGreek.IndexOf(letter), 1);
                    if (nextLetter == "υ" | nextLetter == "ύ")
                    {
                        if (digraphYpsilonBeta.Contains(thirdLetter))
                        {
                            newLetter += "v";
                            cursor += 1;
                        }
                        else if (digraphYpsilonPhi.Contains(thirdLetter))
                        {
                            newLetter += "f";
                            cursor += 1;
                        }
                    }
                }
                else if (letter == "γ")
                {
                    if (nextLetter == "γ")
                    {
                        newLetter = "ng";
                        cursor += 1;
                    }
                    else if (nextLetter == "ξ")
                    {
                        newLetter = "nx";
                        cursor += 1;
                    }
                    else if (nextLetter == "χ")
                    {
                        newLetter = "nch";
                        cursor += 1;
                    }
                    else
                    {
                        newLetter = "g";
                    }
                }
                else if (letter == "μ")
                {
                    if (nextLetter == "π")
                    {
                        if (string.IsNullOrEmpty(previousLetter.Trim()) | string.IsNullOrEmpty(thirdLetter.Trim()))
                        {
                            newLetter = "b";
                            cursor += 1;
                        }
                        else
                        {
                            newLetter = "mp";
                            cursor += 1;
                        }
                    }
                    else
                    {
                        newLetter = "m";
                    }
                }
                else if (letter == "ο")
                {
                    newLetter = "o";
                    if (nextLetter == "υ" | nextLetter == "ύ")
                    {
                        newLetter += "u";
                        cursor += 1;
                    }
                }
                else
                {
                    newLetter = letter;
                }

                if (isUpper)
                {
                    newLetter = newLetter.Substring(0, 1).ToUpper() +
                        (isUpper2 ? newLetter.Substring(1).ToUpper() : newLetter.Substring(1).ToLower());
                }

                result.Append(newLetter);
                cursor++;
            }
            return result.ToString();
        }
    }
}
