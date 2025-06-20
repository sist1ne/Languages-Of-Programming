using System.Security.Cryptography;

namespace compiler
{
    class SyntaxAnalyzer
    {
        static LexicalAnalyzer lexicalAnalyzer;
        static int beginLevel = 0;
        bool skipNext = false;
        bool SemicolonEnable = false;
        bool NewLine = false;

        public SyntaxAnalyzer()
        {
            lexicalAnalyzer = new LexicalAnalyzer();
            InputOutput.AddOnNewLineListener(OnNewLine);
        }

        public bool OnNewLine()
        {
            NewLine = false;
            if (SemicolonEnable)
            {
                if (lexicalAnalyzer.symbol != LexicalAnalyzer.semicolon)
                {
                    InputOutput.Error(85, lexicalAnalyzer.token);
                }
                NewLine = true;
            }
            return true;
        }

        byte LoadHeader()
        {
            lexicalAnalyzer.NextSym();
            if (lexicalAnalyzer.symbol != LexicalAnalyzer.programsy)
            {
                return 255;
            }
            lexicalAnalyzer.NextSym();
            if (lexicalAnalyzer.symbol != LexicalAnalyzer.ident)
            {
                return 255;
            }
            lexicalAnalyzer.NextSym();
            if (lexicalAnalyzer.symbol != LexicalAnalyzer.semicolon)
            {
                return 255;
            }
            return 0;
        }

        public void Analyze()
        {

            byte code = LoadHeader();
            if (code != 0)
            {
                InputOutput.Error(code, lexicalAnalyzer.token);
                return;
            }
            beginLevel = 0;
            while (true)
            {
                code = 0;
                if (!skipNext)
                    lexicalAnalyzer.NextSym();
                skipNext = false;
                switch (lexicalAnalyzer.symbol)
                {
                    case LexicalAnalyzer.endsy:
                        beginLevel--;
                        lexicalAnalyzer.NextSym();
                        if (lexicalAnalyzer.symbol == LexicalAnalyzer.point)
                        {
                            if (beginLevel > 0)
                            {
                                InputOutput.Error(37, lexicalAnalyzer.token);
                            }
                            if (beginLevel < 0)
                            {
                                InputOutput.Error(36, lexicalAnalyzer.token);
                            }
                            return;
                        }
                        break;
                    case LexicalAnalyzer.beginsy:
                        beginLevel++;
                        break;
                    case LexicalAnalyzer.varsy:
                        code = VarConstHandle();
                        break;
                    case LexicalAnalyzer.constsy:
                        code = VarConstHandle();
                        break;
                    case LexicalAnalyzer.ident:
                        break;
                    case LexicalAnalyzer.ifsy:
                        code = IfHandle();
                        break;
                    case LexicalAnalyzer.forsy:
                        code = ForHandle();
                        break;
                    case LexicalAnalyzer.casesy:
                        code = CaseHandle();
                        break;
                    default:
                        break;
                }
                if (code != 0)
                {
                    InputOutput.Error(code, lexicalAnalyzer.token);
                }
                if (InputOutput.EndOfFile)
                {
                    InputOutput.Error(37, lexicalAnalyzer.token);
                    break;
                }
            }
        }

        bool SymbolIsIdentOrSimpleType(byte? symbol = null)
        {
            if (symbol == null)
            {
                symbol = lexicalAnalyzer.symbol;
            }
            return symbol == LexicalAnalyzer.ident ||
                symbol == LexicalAnalyzer.intc ||
                symbol == LexicalAnalyzer.stringc ||
                symbol == LexicalAnalyzer.floatc;
        }


        private void ArrayDeclarationHandle()
        {
            if (lexicalAnalyzer.symbol != LexicalAnalyzer.lbracket)
            {
                InputOutput.Error(95, InputOutput.positionNow);
                return;
            }
            lexicalAnalyzer.NextSym();

                if (lexicalAnalyzer.symbol != LexicalAnalyzer.intc && lexicalAnalyzer.symbol != LexicalAnalyzer.ident)
                {
                    InputOutput.Error(97, InputOutput.positionNow);
                    return; 
                }
                lexicalAnalyzer.NextSym();
                if (lexicalAnalyzer.symbol != LexicalAnalyzer.twopoints)    
                {
                    InputOutput.Error(97, InputOutput.positionNow);
                    return;
                }
                lexicalAnalyzer.NextSym(); 
                if (lexicalAnalyzer.symbol != LexicalAnalyzer.intc && lexicalAnalyzer.symbol != LexicalAnalyzer.ident)
                {
                    InputOutput.Error(32, InputOutput.positionNow); 
                    return;
                }
                lexicalAnalyzer.NextSym();
                if (lexicalAnalyzer.symbol == LexicalAnalyzer.comma)
                {
                    lexicalAnalyzer.NextSym(); 
                }
                else if (lexicalAnalyzer.symbol == LexicalAnalyzer.rbracket)
                {
                    lexicalAnalyzer.NextSym();
                }
                else
                {
                    InputOutput.Error(99, InputOutput.positionNow);
                    return; 
                }


            if (lexicalAnalyzer.symbol != LexicalAnalyzer.ofsy)
            {
                InputOutput.Error(54, InputOutput.positionNow);
                return;
            }
            lexicalAnalyzer.NextSym();

            switch (lexicalAnalyzer.symbol)
            {
                case LexicalAnalyzer.integersy:
                case LexicalAnalyzer.realsy:
                case LexicalAnalyzer.booleansy:
                case LexicalAnalyzer.stringsy:
                case LexicalAnalyzer.charsy:
                    break;
                default:
                    InputOutput.Error(33, InputOutput.positionNow);
                    return;
            }

        }

        byte VarConstHandle()
        {
            lexicalAnalyzer.NextSym();
            while (lexicalAnalyzer.symbol == LexicalAnalyzer.ident)
            {
                while (lexicalAnalyzer.symbol != LexicalAnalyzer.colon)
                {
                    if (lexicalAnalyzer.prevSymbol == LexicalAnalyzer.ident && lexicalAnalyzer.symbol != LexicalAnalyzer.comma)
                    {
                        return 87;
                    }
                    if (lexicalAnalyzer.symbol != LexicalAnalyzer.ident && lexicalAnalyzer.prevSymbol == LexicalAnalyzer.comma)
                    {
                        return 35;
                    }
                    lexicalAnalyzer.NextSym();
                }

                /*
                lexicalAnalyzer.NextSym();
                switch (lexicalAnalyzer.symbol)
                {
                    case LexicalAnalyzer.integersy:
                    case LexicalAnalyzer.realsy:
                    case LexicalAnalyzer.booleansy:
                    case LexicalAnalyzer.stringsy:
                    case LexicalAnalyzer.charsy:
                        break;
                    default:
                        return 33;
                }
                lexicalAnalyzer.NextSym();
                if (lexicalAnalyzer.symbol != LexicalAnalyzer.semicolon)
                {
                    return 85;
                }
                lexicalAnalyzer.NextSym();
                */

                    if (lexicalAnalyzer.symbol == LexicalAnalyzer.arraysy)
                    {
                        lexicalAnalyzer.NextSym();
                        ArrayDeclarationHandle();
                    }
                    else
                    {

                        lexicalAnalyzer.NextSym();
                        switch (lexicalAnalyzer.symbol)
                        {
                            case LexicalAnalyzer.integersy:
                            case LexicalAnalyzer.realsy:
                            case LexicalAnalyzer.booleansy:
                            case LexicalAnalyzer.stringsy:
                            case LexicalAnalyzer.charsy:
                                break;
                            default:
                                return 33;
                        }
                    }
                    lexicalAnalyzer.NextSym();
                    if (lexicalAnalyzer.symbol != LexicalAnalyzer.semicolon)
                    {
                        return 85;
                    }
                    lexicalAnalyzer.NextSym();

            }
            skipNext = true;
            return 0;


        }

        byte IfHandle()
        {
            lexicalAnalyzer.NextSym();
            uint pairLevel = 0;
            while (lexicalAnalyzer.symbol != LexicalAnalyzer.thensy)
            {
                if (!SymbolIsIdentOrSimpleType(lexicalAnalyzer.prevSymbol) &&
                    !SymbolIsIdentOrSimpleType() &&
                    lexicalAnalyzer.symbol != LexicalAnalyzer.leftpar &&
                    lexicalAnalyzer.symbol != LexicalAnalyzer.rightpar)
                    return 35;
                if (!SymbolIsIdentOrSimpleType() &&
                    !SymbolIsIdentOrSimpleType(lexicalAnalyzer.prevSymbol) &&
                    lexicalAnalyzer.symbol != LexicalAnalyzer.leftpar &&
                    lexicalAnalyzer.prevSymbol != LexicalAnalyzer.rightpar)
                    return 35;
                if (SymbolIsIdentOrSimpleType(lexicalAnalyzer.prevSymbol) && SymbolIsIdentOrSimpleType())
                    return 57;
                if (lexicalAnalyzer.symbol == LexicalAnalyzer.leftpar)
                    pairLevel++;
                if (lexicalAnalyzer.symbol == LexicalAnalyzer.rightpar)
                    pairLevel--;
                if (lexicalAnalyzer.symbol == LexicalAnalyzer.semicolon)
                    return 57;
                lexicalAnalyzer.NextSym();
            }
            if (pairLevel > 0)
            {
                return 89;
            }
            return 0;
        }

        byte ForHandle()
        {
            lexicalAnalyzer.NextSym();
            if (lexicalAnalyzer.symbol != LexicalAnalyzer.ident)
            {
                return 35;
            }
            lexicalAnalyzer.NextSym();
            if (lexicalAnalyzer.symbol != LexicalAnalyzer.assign)
            {
                return 91;
            }
            lexicalAnalyzer.NextSym();
            if (lexicalAnalyzer.symbol != LexicalAnalyzer.ident &&
                lexicalAnalyzer.symbol != LexicalAnalyzer.intc &&
                lexicalAnalyzer.symbol != LexicalAnalyzer.floatc)
            {
                return 32;
            }
            lexicalAnalyzer.NextSym();
            if (lexicalAnalyzer.symbol != LexicalAnalyzer.tosy && lexicalAnalyzer.symbol != LexicalAnalyzer.downtosy)
            {
                return 58;
            }
            lexicalAnalyzer.NextSym();
            if (lexicalAnalyzer.symbol != LexicalAnalyzer.ident &&
                lexicalAnalyzer.symbol != LexicalAnalyzer.intc &&
                lexicalAnalyzer.symbol != LexicalAnalyzer.floatc)
            {
                return 32;
            }
            lexicalAnalyzer.NextSym();
            if (lexicalAnalyzer.symbol != LexicalAnalyzer.dosy)
            {
                return 50;
            }
            return 0;
        }

        byte CaseHandle()
        {
            lexicalAnalyzer.NextSym();
            if (!SymbolIsIdentOrSimpleType())
            {
                return 35;
            }
            lexicalAnalyzer.NextSym();
            if (lexicalAnalyzer.symbol != LexicalAnalyzer.ofsy)
            {
                return 54;
            }
            lexicalAnalyzer.NextSym();
            while (lexicalAnalyzer.symbol != LexicalAnalyzer.endsy)
            {
                if (lexicalAnalyzer.symbol == LexicalAnalyzer.elsesy)
                {
                    lexicalAnalyzer.NextSym();
                }
                else
                {
                    if (!SymbolIsIdentOrSimpleType())
                    {
                        InputOutput.Error(35, lexicalAnalyzer.token);
                    }
                    lexicalAnalyzer.NextSym();
                    if (lexicalAnalyzer.symbol != LexicalAnalyzer.twopoints &&
                        lexicalAnalyzer.symbol != LexicalAnalyzer.colon &&
                        lexicalAnalyzer.symbol != LexicalAnalyzer.comma)
                    {
                        InputOutput.Error(86, lexicalAnalyzer.token);
                    }

                    if (lexicalAnalyzer.symbol != LexicalAnalyzer.colon)
                    {
                        lexicalAnalyzer.NextSym();
                        if (!SymbolIsIdentOrSimpleType())
                        {
                            InputOutput.Error(35, lexicalAnalyzer.token);
                        }
                        lexicalAnalyzer.NextSym();
                        if (lexicalAnalyzer.symbol != LexicalAnalyzer.colon)
                        {
                            InputOutput.Error(86, lexicalAnalyzer.token);
                        }
                    }
                }
                SemicolonEnable = true;
                do
                {
                    lexicalAnalyzer.NextSym();
                }
                while (lexicalAnalyzer.symbol != LexicalAnalyzer.semicolon && lexicalAnalyzer.symbol != LexicalAnalyzer.endsy);
                SemicolonEnable = false;
                if (lexicalAnalyzer.symbol == LexicalAnalyzer.endsy)
                {
                    break;
                }
                lexicalAnalyzer.NextSym();
            }
            return 0;
        }
    }
}