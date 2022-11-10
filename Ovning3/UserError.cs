using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning3
{
    internal abstract class UserError
    {
        public abstract string UEMessage();
    }
    internal class NumericInputError:UserError
    {
        public override string UEMessage()
        {
            return "You tried to use a\r\nnumeric input in a text only field. This fired an error!\n";
        }
    }
    internal class TextInputError: UserError
    {
        public override string UEMessage()
        {
            return "You tried to use a text\r\ninput in a numeric only field. This fired an error!\n";
        }
    }
    internal class EmptyInputError : UserError
    {
        public override string UEMessage()
        {
            return "You didn't input any text\r\ninput needs an something to work with. This fired an error!\n";
        }
    }

    //dumma exempel men kommer inte på något bättre
    internal class FloatInputError : UserError
    {
        public override string UEMessage()
        {
            return "You tried to use a float value\r\ninput in a integer only field. This fired an error!\n";
        }
    }
   
    internal class IntInputError : UserError
    {
        public override string UEMessage()
        {
            return "You tried to use an int value\r\ninput in a float only field. This fired an error!\n";
        }
    }
    internal class RangeInputError : UserError
    {
        public override string UEMessage()
        {
            return "You tried to use a value that is too low\r\ninput needs a number above 8. This fired an error!\n";
        }
    }
}
