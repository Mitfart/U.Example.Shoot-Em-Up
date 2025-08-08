namespace Extensions.Color
{
    public static class WithAlphaExt
    {
        public static UnityEngine.Color WithAlpha(this UnityEngine.Color color, float alpha)
        {
            color.a = alpha;
            return color;
        }
    }
}