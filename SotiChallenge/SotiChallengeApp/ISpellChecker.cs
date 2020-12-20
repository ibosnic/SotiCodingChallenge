using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotiChallengeApp
{
    public interface ISpellChecker
    {
        bool IsWordSpelledCorrectly(string word);
    }
}
