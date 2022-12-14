using System.Collections.Immutable;

using Weknow.Generation.SrcGen.Playground;

using Xunit;


namespace Weknow.Text.Json.Extensions.Tests
{
    public class MappingTests
    {

        [Fact]
        public void Class1_Test()
        {
            var c = new Class1 { A = 1, B = 2 };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();
            Class1 c1 = d;
            Class1 c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
        }

        [Fact]
        public void Record3_Test()
        {
            var c = new Record3("Hi", 1) { Z = 2 };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();
            Record3 c1 = d;
            Record3 c2 = di;
            Record3 c3 = (Record3)di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
            Assert.Equal(c, c3);
        }

        [Fact]
        public void Record3_ReadOnly_Test()
        {
            var c = new Record3("Hi", 1) { Z = 2 };
            IReadOnlyDictionary<string, object?> d = c.ToDictionary();
            Record3 c1 = (Record3)(Dictionary<string, object?>)d;

            Assert.Equal(c, c1);
        }

        [Fact]
        public void Record3_Cast_Test()
        {
            var c = new Record3("Hi", 1.6) { Z = 2 };
            var d = c.ToDictionary();
            d[nameof(c.y)] = (decimal)c.y;
            d[nameof(c.Z)] = (long)c.Z;
            //Record3 c1 = Record3.Factory(d);
            Record3 c1 = d;

            Assert.Equal(c, c1);
        }

        [Fact]
        public void Record4_Test()
        {
            var c = new Record4 { A = 1, B = 2 };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();
            Record4 c1 = d;
            Record4 c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
        }

        [Fact]
        public void Record4_Null_Test()
        {
            var c = new Record4 { A = 1 };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();
            Record4 c1 = d;
            Record4 c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
        }

        [Fact]
        public void RecordInheritance_Test()
        {
            var c = new RecordInheritance { A = 1, B = 2, C = 3 };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();
            RecordInheritance c1 = d;
            RecordInheritance c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
        }

        [Fact]
        public void Record5_Test()
        {
            var c = new Record5 { A = 1, B = 2 };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();
            Record5 c1 = d;
            Record5 c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
        }

        [Fact]
        public void Record5_Null_Test()
        {
            var c = new Record5 { A = 1 };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();
            Record5 c1 = d;
            Record5 c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
        }

        [Fact]
        public void Struct5_Test()
        {
            var c = new Struct5 { A = 1, B = 2 };
            IReadOnlyDictionary<string, object> d = c.ToDictionary().ToDictionary(m => m.Key, m => m.Value ?? throw new Exception());
            Struct5 c1 = Struct5.FromReadOnlyDictionary(d);

            Assert.Equal(c, c1);
        }

        [Fact]
        public void Struct5_Nullable_Test()
        {
            var c = new Struct5 { A = 1, B = 2 };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();
            Struct5 c1 = d;
            Struct5 c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
        }

        [Fact]
        public void Struct5_Null_Test()
        {
            var c = new Struct5 { A = 1 };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();
            Struct5 c1 = d;
            Struct5 c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
        }

        [Fact]
        public void RecordEnum_Test()
        {
            var c = new RecordEnum("1", ConsoleColor.Cyan) { Background = ConsoleColor.Red, Name = "Yos" };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();

            RecordEnum c1 = d;
            RecordEnum c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
            Assert.Equal(typeof(string), d["Background"].GetType());
            Assert.Equal(typeof(string), di["Background"].GetType());
        }

        [Fact]
        public void RecordPascal_Test()
        {
            var c = new RecordPascal("is huge") { NothingNew = "That right" };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();

            RecordPascal c1 = d;
            RecordPascal c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
            Assert.True(d.ContainsKey("WallOfChina"));
            Assert.True(d.ContainsKey("NothingNew"));
            Assert.True(di.ContainsKey("WallOfChina"));
            Assert.True(di.ContainsKey("NothingNew"));
        }

        [Fact]
        public void RecordCamel_Test()
        {
            var c = new RecordCamel("is huge") { NothingNew = "That right" };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();

            RecordCamel c1 = d;
            RecordCamel c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
            Assert.True(d.ContainsKey("wallOfChina"));
            Assert.True(d.ContainsKey("nothingNew"));
            Assert.True(di.ContainsKey("wallOfChina"));
            Assert.True(di.ContainsKey("nothingNew"));
        }

        [Fact]
        public void RecordDash_Test()
        {
            var c = new RecordDash("is huge") { NothingNew = "That right" };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();

            RecordDash c1 = d;
            RecordDash c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
            Assert.True(d.ContainsKey("wall-of-china"));
            Assert.True(d.ContainsKey("nothing-new"));
            Assert.True(di.ContainsKey("wall-of-china"));
            Assert.True(di.ContainsKey("nothing-new"));
        }

        [Fact]
        public void RecordScream_Test()
        {
            var c = new RecordScream("is huge") { NothingNew = "That right" };
            Dictionary<string, object?> d = c.ToDictionary();
            ImmutableDictionary<string, object?> di = c.ToImmutableDictionary();

            RecordScream c1 = d;
            RecordScream c2 = di;

            Assert.Equal(c, c1);
            Assert.Equal(c, c2);
            Assert.True(d.ContainsKey("WALL_OF_CHINA"));
            Assert.True(d.ContainsKey("NOTHING_NEW"));
            Assert.True(di.ContainsKey("WALL_OF_CHINA"));
            Assert.True(di.ContainsKey("NOTHING_NEW"));
        }
    }
}
