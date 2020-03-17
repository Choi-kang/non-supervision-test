# MachineLearningID3
决策树之 ID3 算法（待续）

----------------------------------------------

# 源数据
|  Day  |    OutLook      |   Temperature   |   Humidity   |   Wind   |   PlayTennis   |
| :---: | :-------------: | :-------------: | :----------: | :------: | :------------: |
|   1   |  Sunny          |  Hot            |  High        |  Weak    |  No            |
|   2   |  Sunny          |  Hot            |  High        |  Strong  |  No            |
|   3   |  Overcast       |  Hot            |  High        |  Weak    |  Yes           |
|   4   |  Rainy          |  Mild           |  High        |  Weak    |  Yes           |
|   5   |  Rainy          |  Cool           |  Normal      |  Weak    |  Yes           |
|   6   |  Rainy          |  Cool           |  Normal      |  Strong  |  No            |
|   7   |  Overcast       |  Cool           |  Normal      |  Strong  |  Yes           |
|   8   |  Sunny          |  Mild           |  High        |  Weak    |  No            |
|   9   |  Sunny          |  Cool           |  Normal      |  Weak    |  Yes           |
|   10  |  Rainy          |  Mild           |  Normal      |  Weak    |  Yes           |
|   11  |  Sunny          |  Mild           |  Normal      |  Strong  |  Yes           |
|   12  |  Overcast       |  Mild           |  High        |  Strong  |  Yes           |
|   13  |  Overcast       |  Hot            |  Normal      |  Weak    |  Yes           |
|   14  |  Rainy          |  Mild           |  High        |  Strong  |  No            |

# 决策树
```text
OutLook
    Sunny->Humidity
        High->No
        Normal->Yes
    Overcast->Yes
    Rainy->Wind
        Weak->Yes
        Strong->No
```

# Ref
-   http://blog.csdn.net/acdreamers/article/details/44661149
-   http://www.cnblogs.com/leoo2sk/archive/2010/09/19/decision-tree.html

-----------------------------------------

本代码博客地址： [决策树之 ID3 算法](http://blog.csdn.net/lemon_tree12138/article/details/51837983)
