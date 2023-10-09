# Post-jam Devlog

First off, thank you to the organizers of the Cozy Fall Jam 2023! You put together the right community and atmosphere to make this a (mostly) stress-free jam.

Also, this was my very first game jam. I learned a lot and had a blast! As a father of 2 with a full-time day job I was worried 4 days wouldn't be enough time to build something worth submitting. However, I learned a lot over the course of the jam, including the fact that 4 days was just enough time.

## The game

Before getting too technical, I should talk about the actual game. The general theme of the jam was simply cozy & fall themed. With my wife's help branstorming, I already had a list of a few fall-themed ideas. However I didn't want to commit to one until the sub-theme was announced.

In my Notion page I had this list:
- Autumn solstice festival
- Butterfly migration
- Journey of Persephone

After watching a few videos about the migrations of monarch butterflies I had the most inspiration for option 2. Once the jam started, the sub-theme was announced to be "less is more".

After a bit more brainstorming I put together a game concept around butterfly navigation. Scientists believe monarch butterflies are able to navigate long distances to a specific location each year using a combination of an internal clock and the position of the sun!

[Here's a great video from PBS on the subject.](https://www.youtube.com/watch?v=fBakLuH6kDY)

The original concept for my game was sort of a combination of flappy bird and geoguesser, where you needed to preserve energy by flapping your wings at a cozy pace (less is more) while using the position of the sun to navigate to a pre-determined location on a procedurally generated map. After putting together a quick prototype I realized the flappy bird part of this wasn't very fun. It was more tedious than anything and difficult to balance.

After tweaking the game a bit I realized it was actually fun to just flutter around the map as a butterfly free from the grasp of gravity. This idea led me to focus more on the feeling of being a butterfly in a big forest which ultimately is what I submitted as my game.

[You can play it here on itch.io!](https://fleetfoxx.itch.io/migrate)

## Goals

Before even joining the jam my main goal was to challenge myself to create something small as a break from my larger projects. Once I had figured out a general direction for my game my main goals became

1. Create all the assets myself. This included the 3D models, music, code, etc.
2. Learn something new about shaders.
3. Have fun. I didn't want this experience to create any extra stress, so I never pushed myself to stay up late to finish a feature or worry about the deadline. I would submit what I had at the end of the jam and call it a day.

## Lessons learned

So did I achieve my goals? Let's see...

### Creating all the assets myself.

This is something I am already pretty familiar with. I love making pixel art for my games and I jam in ableton all the time. However my 3D skills are still in the "I forgot the keyboard shortcut already so let me search through every menu to find the one thing I want to do" category.

I'm very happy I kept this goal. I am very proud of the work I did in Blender for this jam (my favorites are the monarch butterfly model and the mushroom). The deadline pushed me to optimize my workflow on-the-fly and I think my 3D skills have grown as a result. I learned how to use a single vertex to outline a reference image and turn it into a 3D object. I also finally learned the classic extrude > scale > rotate method for quickly blocking out a model.

I'm also very proud of the music I made for the game. I've made generative music before so I was already familiar with this process in Ableton. In fact, after slapping midi randomizers on a couple of piano VSTs and a violin I had to name my audio file "NotMinecraft.ogg" to make sure I could prove I didn't just straight up rip it from the Minecraft soundtrack. In my opinion it really matched the cozy yet adventurous vibe of the game I was going for despite being randomly generated.

The only thing I didn't make were the outdoor sound effects. A recording of my back-yard would include street racing, drunk neighbors, and raccoons crawling through trash cans which didn't really fit the vibe.

### Shaders 😲

My previous experience with shaders was mostly hacking something together using pieces of shader code from the internet, however I never took the time to truly understand how they worked. 

For this game I decided to texture the planet using the VisualShader material in Godot. I found the guard rails imposed by the VisualShader editor to be a great way to experiment without getting too in the weeds with shader code.

### Have fun

By starting the jam with low expectations for myself I ended up having a great time. I kept the scope small, experimented with features I thought might be fun, and ultimately created something I was proud of.

I intentionally gave myself an hour of padding before the jam ended to test the final build on itch.io and I'm very glad I did. I ran into a few issues that would have been game breakers had I waited until the last minute to submit. 

First, I learned that there is a file size limit on itch.io that I accidentally exceeded with some of the unused files included in the .pck file included in the build. After deleting the unused files and converting my audio files to .ogg format I was able to drastically decrease the final game size to make itch.io happy. 

Second, I discovered that the method I used to simulate movement (rotate the entire planet and everything on it) was causing some noticeable lag in the browser that wasn't obvious on my PC. I was fortunately able to come up with a quick solution where I only move the character and the planet could remain static. In hindsight this was the solution I should have been using the entire time.

## Final thoughts

Ultimately I had a great time and will definitely be doing more jams in the future. I'm excited to work more on my modeling and shader skills in the mean time and apply them to my main projects.

❤️✌️ _~ff_