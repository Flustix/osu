// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Linq;
using NUnit.Framework;
using osu.Framework.Bindables;
using osu.Game.Configuration;

namespace osu.Game.Tests.Mods
{
    [TestFixture]
    public class SettingsSourceAttributeTest
    {
        [Test]
        public void TestOrdering()
        {
            var objectWithSettings = new ClassWithSettings();

            var orderedSettings = objectWithSettings.GetOrderedSettingsSourceProperties().ToArray();

            Assert.That(orderedSettings, Has.Length.EqualTo(3));
        }

        private class ClassWithSettings
        {
            [SettingSource("Second setting", "Another description", 2)]
            public BindableBool SecondSetting { get; set; } = new BindableBool();

            [SettingSource("First setting", "A description", 1)]
            public BindableDouble FirstSetting { get; set; } = new BindableDouble();

            [SettingSource("Third setting", "Yet another description", 3)]
            public BindableInt ThirdSetting { get; set; } = new BindableInt();
        }
    }
}
