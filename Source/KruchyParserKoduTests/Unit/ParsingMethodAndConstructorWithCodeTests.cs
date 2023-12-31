﻿using FluentAssertions;
using KruchyParserKodu.ParserKodu;
using KruchyParserKodu.ParserKodu.Models;
using KruchyParserKodu.ParserKodu.Models.Instructions;
using KruchyParserKoduTests.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace KruchyParserKoduTests.Unit
{
    [TestFixture]
    public class ParsingMethodAndConstructorWithCodeTests
    {
        FileWithCode parsedCode;

        IList<Instruction> _contructorInstructions;

        Constructor _constructor;

        Instruction _constructorInstruction1;

        Instruction _constructorInstruction2;

        Method _method;

        IList<Instruction> _methodInstructions;

        Instruction _methodInstruction1;

        Instruction _methodInstruction2;

        [SetUp]
        public void SetUpEachTest()
        {
            parsedCode = Parser.Parse(
                new WczytywaczZawartosciPrzykladow()
                    .DajZawartoscPrzykladu("MethodAndConstructorWithCode.cs"));

            _constructor = parsedCode.DefinedItems.Single().Constructors.Single();

            _contructorInstructions = _constructor.Instructions;

            if (_contructorInstructions != null)
            {
                _constructorInstruction1 = _contructorInstructions.FirstOrDefault();

                _constructorInstruction2 = _contructorInstructions.Skip(1).FirstOrDefault();
            }

            _method = parsedCode.DefinedItems.Single().Methods.Single();

            _methodInstructions = _method.Instructions;

            if ( _methodInstructions != null )
            {
                _methodInstruction1 = _methodInstructions.FirstOrDefault();

                _methodInstruction2 = _methodInstructions.Skip(1).FirstOrDefault();
            }
        }

        [Test]
        public void ParsedCode_Constructor_ShouldHaveInstructions()
        {
            _contructorInstructions.Should().HaveCount(2);
        }

        [Test]
        public void ParsedCode_Constructor_ShouldInstructionsSetPosition()
        {
            _constructorInstruction1.StartPosition.Row.Should().Be(10);

            _constructorInstruction1.StartPosition.Column.Should().Be(13);

            _constructorInstruction1.EndPosition.Row.Should().Be(10);

            _constructorInstruction1.EndPosition.Column.Should().Be(22);

            _constructorInstruction2.StartPosition.Row.Should().Be(12);

            _constructorInstruction2.StartPosition.Column.Should().Be(13);

            _constructorInstruction2.EndPosition.Row.Should().Be(12);

            _constructorInstruction2.EndPosition.Column.Should().Be(28);
        }

        [Test]
        public void ParsedCode_Constructor_ShouldInstructionsSetText()
        {
            _constructorInstruction1.Text.Should().Be("_a1 = a1;");

            _constructorInstruction2.Text.Should().Be("var v1 = 1 + 2;");
        }

        [Test]
        public void ParsedCode_Constructor_ShouldInstructionsHaveSetCodeUnit()
        {
            _constructorInstruction1.CodeUnit.Should().Be(_constructor);

            _constructorInstruction2.CodeUnit.Should().Be(_constructor);
        }

        [Test]
        public void ParsedCode_Constructor_ShouldInstruction1BeOfTypeAssignmentInstruction()
        {
            _constructorInstruction1.GetType().Should().Be(typeof(AssignmentInstruction));
        }

        [Test]
        public void ParsedCode_Method_ShouldHaveInstructions()
        {
            _methodInstructions.Should().HaveCount(2);
        }

        [Test]
        public void ParsedCode_Method_ShouldInstructionsSetPosition()
        {
            _methodInstruction1.StartPosition.Row.Should().Be(17);

            _methodInstruction1.StartPosition.Column.Should().Be(13);

            _methodInstruction1.EndPosition.Row.Should().Be(17);

            _methodInstruction1.EndPosition.Column.Should().Be(26);

            _methodInstruction2.StartPosition.Row.Should().Be(19);

            _methodInstruction2.StartPosition.Column.Should().Be(13);

            _methodInstruction2.EndPosition.Row.Should().Be(22);

            _methodInstruction2.EndPosition.Column.Should().Be(14);
        }

        [Test]
        public void ParsedCode_Method_ShouldInstructionsHaveSetCodeUnit()
        {
            _methodInstruction1.CodeUnit.Should().Be(_method);

            _methodInstruction2.CodeUnit.Should().Be(_method);
        }
    }
}
