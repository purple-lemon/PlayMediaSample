# PlayMediaSample

Simple project with code that can be used to operate with media files. It uses windows components, same as Windows media player use. So it can play media that possible to play by Windows media even if it in custom codecs. Actually I investigated how to do following things without any extra nuget packages:
* Play media
* Get Media natural duration
* Get Media screen (frame) at specified moment. 
* Also it contains part of Mictosoft API test reference, that was used to get Screen snapshot. Since it may be used to compare screens and verify video screen changes, it's has one solid color or percents of changes between different seconds with help of Histogram
