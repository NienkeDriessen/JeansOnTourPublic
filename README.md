# \# README Sustainable Fashion

# 

# \## Sustainable fashion explained

# 

# 

# \## 1. The code

# The code is intended to be used in Unity. The repository is public and exists here: 

# https://github.com/NienkeDriessen/JeansOnTourPublic.git

# 

# It exists of 6 scenes;

# \- Welcome

# \- Quiz question 1

# \- Quiz question 2

# \- Quiz question 3

# \- Puzzle

# \- Video

# 

# The table on which the demo is performed only contains a build of this repository. How to add a new build will be discussed below.

# 

# \### The components

# 

# The \_\_slide manager\_\_ ensures that navigation between slides works. Navigation works with a clicker, so these commands determine whether the current view moves forward or backward. 

# The necessary scripts for this can be found in the tab \_\_scripts\_\_/SlideShow

# 

# The \_\_Quiz Manager\_\_  is added to each quiz slide. In the inspector, you can edit the question, the possible answers, and the index of the correct answer {0,1,2,3}.

# 

# In the \_\_Puzzle Scene\_\_, all pattern pieces (with the tag JeansPart) must be placed within the bounds of the JeansFabric. The CanvasGroup.alpha of the cut button (CutOut -> Cut) is then set to 1 and becomes visible. No JeansParts may collide with each other. When cutting, the JeansParts are coloured grey and the (high) score is calculated. The following scripts have been written for this purpose:

# 

# BoundingBox.cs

# Determines the bounds within which the JeansParts lie and the percentage of the fabric that this covers. Places the objects of the bounds (Bounds -> LeftBound etc.) in the correct place.

# 

# Collision.cs

# CutOut.cs

# DragDrop.cs

# HighScore.cs

# JeansOnFabric.cs

# NoVelocity.cs

# percentageText.cs

# Restart.cs

# 

# \## 4. How to add a new slide or edit the order

# If you want to add, say, a new quiz slide, you add a new scene in the Project / assets / scenes

# Then you can make sure the slide manager uses it by going to File --> Build Settings -> there is a list of all possible scenes. Make sure the scenes you want are checked, and in the right order. 

# 

# \## 2. How to export a new version

# File --> Build Settings -> Build

# 

# \## 3. How to put new version on the table

# If you want to update the table, you need to build the game to a USB and put that file on the PC. Then press the Windows logo + R -> Open ‘shell:startup’ and put a shortcut to the app there. And delete the old one.

# 

# !\[This is an alt text.](/image/sample.webp "This is a sample image.")

# 

# \## Links

# 

# You may be using \[Markdown Live Preview](https://markdownlivepreview.com/).

# 

# 

