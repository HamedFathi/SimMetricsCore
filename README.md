![opacity](https://user-images.githubusercontent.com/8418700/140907888-9ced967b-8ade-4bd5-ac1e-903b76c360ef.png)

### [Nuget](https://www.nuget.org/packages/SimMetricsCore)

![Nuget](https://img.shields.io/nuget/v/SimMetricsCore)
![Nuget](https://img.shields.io/nuget/dt/SimMetricsCore)


```
Install-Package SimMetricsCore

dotnet add package SimMetricsCore
```

<hr/>

`SimMetricsCore` supports the following algorithms

```
BlockDistance
ChapmanLengthDeviation
ChapmanMeanLength
CosineSimilarity
DiceSimilarity
EuclideanDistance
JaccardSimilarity
Jaro 
JaroWinkler 
Levenstein // Default
MatchingCoefficient 
MongeElkan
NeedlemanWunch 
OverlapCoefficient
QGramsDistance
SmithWaterman 
SmithWatermanGotoh
SmithWatermanGotohWindowedAffine
```


### Extension Methods


```cs
// GetSimilarity
// [0-1] => [0%-100%] similarity 
double GetSimilarity(this string firstWord, string secondWord, SimMetricType simMetricType = SimMetricType.Levenstein, bool convertToPercentage = false)
SimMetricResult GetMinSimilarityInfo(this string first, IEnumerable<string> second, SimMetricType simMetricType = SimMetricType.Levenstein, bool convertToPercentage = false)

// GetSimilarities
// Get similarity score for each input.
IEnumerable<SimMetricResult> GetSimilarities(this string first, IEnumerable<string> second, SimMetricType simMetricType = SimMetricType.Levenstein, bool convertToPercentage = false)
IEnumerable<SimMetricResult> GetSimilarities(this string first, string[] second, SimMetricType simMetricType = SimMetricType.Levenstein, bool convertToPercentage = false)

// GetMinSimilarity
// Returns the first item that has the least similarity.
string GetMinSimilarity(this string first, IEnumerable<string> second, SimMetricType simMetricType = SimMetricType.Levenstein, bool convertToPercentage = false)
SimMetricResult GetMinSimilarityInfo(this string first, IEnumerable<string> second, SimMetricType simMetricType = SimMetricType.Levenstein, bool convertToPercentage = false)

// GetMinSimilarities
// Returns the items that have the least similarity. 
// A list can contain unique items with the same similarity score.
IEnumerable<string> GetMinSimilarities(this string first, IEnumerable<string> second, SimMetricType simMetricType = SimMetricType.Levenstein, bool convertToPercentage = false)
IEnumerable<SimMetricResult> GetMinSimilaritiesInfo(this string first, IEnumerable<string> second, SimMetricType simMetricType = SimMetricType.Levenstein, bool convertToPercentage = false)

// GetMaxSimilarity
// Returns the first item that has the most similarity.
string GetMaxSimilarity(this string first, IEnumerable<string> second, SimMetricType simMetricType = SimMetricType.Levenstein, bool convertToPercentage = false)
SimMetricResult GetMaxSimilarityInfo(this string first, IEnumerable<string> second, SimMetricType simMetricType = SimMetricType.Levenstein, bool convertToPercentage = false)

// GetMaxSimilarities
// Returns the items that have the most similarity. 
// A list can contain unique items with the same similarity score.
IEnumerable<string> GetMaxSimilarities(this string first, IEnumerable<string> second, SimMetricType simMetricType = SimMetricType.Levenstein, bool convertToPercentage = false)
IEnumerable<SimMetricResult> GetMaxSimilaritiesInfo(this string first, IEnumerable<string> second, SimMetricType simMetricType = SimMetricType.Levenstein, bool convertToPercentage = false)

// Contains
// Getting closer to '1.0' for the 'threshold' increases the accuracy of the comparison.
bool ContainsFuzzy(this string source, string search, double threshold = 0.7, SimMetricType simMetricType = SimMetricType.Levenstein)
// Returns approved values from the 'source' items.
IEnumerable<string> ContainsFuzzy(this IEnumerable<string> source, string search, double threshold = 0.7, SimMetricType simMetricType = SimMetricType.Levenstein)
IEnumerable<string> ContainsFuzzy(this string[] source, string search, double threshold = 0.7, SimMetricType simMetricType = SimMetricType.Levenstein)
```

`SimMetricResult` class contains the following data:

```cs
public class SimMetricResult
{
    public string Item { get; set; }
    // [0-1] => [0%-100%] similarity 
    public double Score { get; set; }
}
```

<hr/>
<div>Icons made by <a href="https://www.freepik.com" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/" title="Flaticon">www.flaticon.com</a></div>
