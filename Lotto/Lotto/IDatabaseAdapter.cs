using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lotto
{
    public interface IDatabaseAdapter
    {
        Lottoschein LeseLottoscheinAusDb();
        void SchreibeLottoscheinInDb(Lottoschein lottoschein);
        void SchreibeZiehungInDb(Ziehung ziehung);

    }
}
