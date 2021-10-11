using System.Collections.Generic;

namespace FakerTest
{
    public class Foo
    {
        public Bar bar;
        public List<Bar> barList;
        private int _intValue;
        private byte _byteValue;

        public string stringValue
        {
            get; set;
        }

        public Foo(int intValue, byte byteValue)
        {
            _intValue = intValue;
            _byteValue = byteValue;
        }

        public Foo(int intValue, byte byteValue, string stringValue)
        {
            _intValue = intValue;
            _byteValue = byteValue;
            this.stringValue = stringValue;
        }

        public override string ToString()
        {

            return ("\n\nDouble Bar: " + bar.barbariki + ", int: " + _intValue + ", byte:" + _byteValue +
                ", \nstring: " + stringValue);
        }
    }
}
