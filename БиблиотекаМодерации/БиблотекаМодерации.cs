using System;

namespace БиблиотекаМодерации
{
    public abstract class Антимат : БазаМата
    {
        public static bool ФильтрацияМата(string Сообщение)
        {
            foreach (string СловоМат in МБ)
            {

                if (СловоМат == Сообщение)
                {
                    
                    return true;
                }
            }
            return false;
        }
    }
}
