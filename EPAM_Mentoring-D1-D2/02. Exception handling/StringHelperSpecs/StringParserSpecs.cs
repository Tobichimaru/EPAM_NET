using System;
using Machine.Specifications;
using StringHelper;

namespace StringHelperSpecs
{
    public class StringParserSpecs
    {
        private static string _initial;
        private static int _obtained;
        private static int _expected;
        private static Exception _exception;

        public class when_parsing_positive_integer
        {
            private Establish context = () =>
            {
                _initial = "123123123";
                _expected = 123123123;
            };

            private Because of = () => { _obtained = _initial.ToInt(); };

            private It should_be_equal = () => { _obtained.ShouldEqual(_expected); };
        }

        public class when_parsing_negative_integer
        {
            private Establish context = () =>
            {
                _initial = "-123123123";
                _expected = -123123123;
            };

            private Because of = () => { _obtained = _initial.ToInt(); };

            private It should_be_equal = () => { _obtained.ShouldEqual(_expected); };
        }

        public class when_parsing_null_string
        {
            private Establish context = () =>
            {
                _initial = null;
            };

            private Because of = () => _exception = Catch.Exception(() => _initial.ToInt());

            private It should_generate_null_reference_exception = () =>
                _exception.ShouldBeOfExactType<NullReferenceException>();

            private It throws_an_exception = () =>
                _exception.ShouldNotBeNull();
        }

        public class when_parsing_invalid_string
        {
            private Establish context = () =>
            {
                _initial = "dfgd";
            };

            private Because of = () => _exception = Catch.Exception(() => _initial.ToInt());

            private It should_generate_argument_exception = () =>
                _exception.ShouldBeOfExactType<ArgumentException>();

            private It throws_an_exception = () =>
                _exception.ShouldNotBeNull();
        }

        public class when_parsing_long_string
        {
            private Establish context = () =>
            {
                _initial = "1111111111111111111111111111111";
            };

            private Because of = () => _exception = Catch.Exception(() => _initial.ToInt());

            private It should_argument_exception = () =>
                _exception.ShouldBeOfExactType<ArgumentException>();

            private It throws_an_exception = () =>
                _exception.ShouldNotBeNull();
        }
    }
}
