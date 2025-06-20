namespace compiler
{
    class ErrorsTable
    {
        static public Dictionary<byte, string> errors = new Dictionary<byte, string>()
        {
            [35] = "нужен идентификатор метки",
            [203] = "переполнение динамически распределяемой области памяти",
            [87] = "требуется указать \",\"",
            [33] = "нужен идентификатор типа",
            [85] = "требуется указать \";\"",
            [57] = "требуется then",
            [89] = "требуется указать \")\"",
            [91] = "требуется указать \":=\"",
            [32] = "нужна целая или действительная константа",
            [58] = "требуется to или downto",
            [50] = "нужен оператор do",
            [36] = "нужен begin",
            [37] = "нужен end",
            [100] = "несоответствие длины строковой переменной или константы",
            [54] = "требуется of",
            [86] = "требуется указать \":\"",

            [95] = "ожидается [",
            [97] = "ожидается ..",
            [99] = "ожидается ',' или ']'"
        };
    }
}