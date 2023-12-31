﻿using System.Linq;
using FluentAssertions;
using KruchyParserKodu.ParserKodu;
using KruchyParserKoduTests.Utils;
using NUnit.Framework;

namespace KruchyParserKoduTests.Unit
{
    [TestFixture]
    public class ParsowanieKonstruktoraZNadklasyTests
    {
        [Test]
        public void ParsujeParametryKonstruktoraZBase()
        {
            //arrange
            var zawartosc =
                new WczytywaczZawartosciPrzykladow()
                    .DajZawartoscPrzykladu("KontruktorZNadKlasy.cs");

            //act
            var sparsowane = Parser.Parse(zawartosc);

            //assert
            var konstruktor =
                sparsowane
                    .DefinedItems
                        .Single()
                            .Constructors
                                .Single();
            var parametrKonstruktoraZNadklasy
                = konstruktor.ParentClassContructorParameters.SingleOrDefault();

            parametrKonstruktoraZNadklasy.Should().NotBeNull();
            parametrKonstruktoraZNadklasy.Should().Be("serwis0");
            konstruktor.InitializationKeyWord.Should().Be("base");
        }
    }
}
