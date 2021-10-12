using Firebase.Database;
using UnityEngine;
using Firebase;

public class FirebaseManager : MonoBehaviour
{
    public static int[] Group { get => group; private set => group = value; }

    private static DatabaseReference reference;
    private static int[] group;

    private void Awake()
    {
        group = new int[3];

        reference = FirebaseDatabase.DefaultInstance.RootReference;

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitFB();
            }
            else
            {
                Debug.LogError(string.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });

    }

    private void InitFB()
    {
        reference.ValueChanged += groupValueChanged;
    }

    private void groupValueChanged(object sender, ValueChangedEventArgs e)
    {
        for (int i = 1; i < 4; i++)
        {
            group[i - 1] = int.Parse(e.Snapshot.Child("group").Child($"{i}").Value.ToString());
        }
    }

    public static void PushData()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        string name = PlayerData.PlayerName;
        int bobrSel = PlayerData.SelectedBobr;
        float[] timeSpent = PlayerData.TimeSpentInArea;
        float compDist = PlayerData.CompletedDistance;
        int cc = PlayerData.TotalChocolatesCollected;
        int chocolatesEaten = PlayerData.ChocolatesEaten;
        int trCount = PlayerData.TrophiesCollectedCount;
        bool gf = PlayerData.GalleryFound;

        Profile user = new Profile(name, PlayerData.Group, bobrSel,
            timeSpent[0],timeSpent[1],timeSpent[2],timeSpent[3], compDist, cc,chocolatesEaten,trCount,gf);

        string json = JsonUtility.ToJson(user);
        var p = reference.Push();
        reference.Child(p.Key + "/").SetRawJsonValueAsync(json);

        if (!System.IO.File.Exists(Application.persistentDataPath + "/marker.txt"))
        {
            group[PlayerData.Group - 1]++;
            Group _group = new Group(group);
            string groupJSON = JsonUtility.ToJson(_group);
            groupJSON = groupJSON.Remove(0, groupJSON.LastIndexOf('[') + 1);
            groupJSON = groupJSON.Remove(groupJSON.LastIndexOf(']'));
            string[] arrJSON = groupJSON.Split(',');
            reference.Child("group/1/").SetValueAsync(int.Parse(arrJSON[0]));
            reference.Child("group/2/").SetValueAsync(int.Parse(arrJSON[1]));
            reference.Child("group/3/").SetValueAsync(int.Parse(arrJSON[2]));
        }

        SaveData.MarkGroup();

    }
}
public class Group
{
    public int[] peopleInGroup;
    public Group(int[] peopleInGroup)
    {
        this.peopleInGroup = peopleInGroup;
    }
}
public class Profile
{
    public string _name;
    public int _group;
    public int _selectedBobr;
    public float _totalTime;
    public float _timeRed;
    public float _timeYellow;
    public float _timeGreen;
    public float _timeGallery;
    public float _completedDistance;
    public int _chocolatesCount;
    public int _chocolatesEaten;
    public int _trophiesCount;
    public bool _galleryFound;

    public Profile(string name, int group, int selectedBobr, 
        float timeR,float timeY, float timeGreen, float timeGallery, float completedDistance, int chocolatesCount,
        int chocolatesEaten,int trCount,bool galleryFound)
    {
        _name = name;
        _group = group;
        _selectedBobr = selectedBobr;
        _timeRed = timeR;
        _timeYellow = timeY;
        _timeGreen = timeGreen;
        _timeGallery = galleryFound? timeGallery:0;
        _totalTime = timeR + timeY + timeGallery + timeGallery;
        _completedDistance = completedDistance;
        _chocolatesCount = chocolatesCount;
        _chocolatesEaten = chocolatesEaten;
        _trophiesCount = trCount;
        _galleryFound = galleryFound;
    }
}