namespace SimMetricsCore
{
    public enum SimMetricType
    {
        BlockDistance,
        ChapmanLengthDeviation,
        ChapmanMeanLength,
        CosineSimilarity,
        DiceSimilarity,
        EuclideanDistance,
        JaccardSimilarity,
        Jaro,
        JaroWinkler,
        Levenstein, // Default
        MatchingCoefficient,
        MongeElkan,
        NeedlemanWunch,
        OverlapCoefficient,
        QGramsDistance,
        SmithWaterman,
        SmithWatermanGotoh,
        SmithWatermanGotohWindowedAffine
    }
}