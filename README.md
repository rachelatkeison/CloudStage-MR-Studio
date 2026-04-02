# ✧ CloudStage MR Studio

> *a spatial audio performance environment powered by a real-time external synthesis bridge*

---

## ♡ Overview

**CloudStage MR Studio** is an experimental mixed-reality audio environment where sound is generated, transmitted, and experienced across multiple systems in real time.

Users exist within a 3D world as either:

✦ **performers** — generating sound through interactive instruments
✦ **listeners** — exploring spatial audio environments

At the core of the system is the **CloudStage Synth Bridge** — a real-time audio engine built with JUCE that connects Unity interaction to external synthesis.

This creates a pipeline where:

> ✦ *physical interaction in a virtual space directly drives a real audio engine* ✦

---

## ✧ Core System Components

### ♫ CloudStage (Unity Environment)

* 3D interactive performance space
* role-based system (listener vs performer)
* spatial audio positioning
* real-time visual feedback

### ✧ CloudStage Synth Bridge (JUCE / Projucer App)

* external real-time synthesis engine
* receives MIDI / note events from Unity
* generates audio independently of the game engine
* designed for low-latency audio processing

### ♡ Interaction Pipeline

* Unity captures input + movement
* events are translated into musical data
* data is sent to the Synth Bridge
* audio is generated and spatialized back into the environment

---

## ✧ System Architecture

```
Unity 3D Environment
   ↓
Interaction Layer (Input / Movement / Roles)
   ↓
MIDI / Event Translation
   ↓
CloudStage Synth Bridge (JUCE Audio Engine)
   ↓
Real-Time Audio Output
   ↓
Spatial Rendering in Environment
```

This architecture separates:

✦ interaction logic
✦ audio generation
✦ spatial rendering

resulting in a more scalable and professional audio system design.

---

## ✧ Why This Matters

Most Unity-based audio systems rely entirely on the engine’s built-in audio.

CloudStage instead:

✦ uses an external synthesis engine
✦ enables higher-quality DSP possibilities
✦ mirrors real-world DAW/plugin workflows

This approach aligns more closely with:

* professional audio software
* plugin-based music production systems
* real-time performance environments

---

## ✧ Core Capabilities

### ♫ Spatial Audio Interaction

* sound changes based on position in 3D space
* proximity-based perception
* immersive listening environments

### ✧ Real-Time Performance

* playable in-world keyboard
* note-triggered synthesis
* responsive audio generation

### ♡ External Audio Engine Integration

* Unity → JUCE communication pipeline
* real-time event-driven synthesis
* separation of audio and visual systems

### ✧ Reactive Visual System

* environment responds to audio events
* lighting and objects reflect performance
* feedback loop between sound and visuals

---

## ✧ Integration with Aureine Audio Systems

CloudStage connects with a larger ecosystem:

* ✦ **LumenBloom** — advanced synthesis engine (C++ / JUCE)
* ✦ **Aureine Music Box** — harmonic analysis + generative intelligence

Together, these systems explore:

> ✦ intelligent, expressive, and spatial music technology ✦

---

## ✧ Demo

🎥 *Demo video:* [https://youtu.be/NzFsLJeiPeg]

---

## ✧ Screenshots

### ♡ Environment & Stage

![CloudStage Environment](images/theater-wide.png)

![Active Stage View](images/theateractivated.png)

---

### ✧ Role-Based Experience

![Main Menu](images/menu.png)

![Performer View](images/performerpov.png)

---

### ♫ Interactive Performance

![Piano Interaction](images/in-piano.png)

![Keyboard Close View](images/piano-pov.png)

---

### ✧ External Audio Engine (Synth Bridge)

![Synth Bridge Running](images/projucer-app.png)

---

## ✧ Technologies Used

* Unity (C#)
* JUCE (C++)
* Projucer
* MIDI / event-driven systems
* real-time audio processing
* 3D spatial interaction design

---

## ✧ Key Design Focus

* real-time responsiveness
* low-latency audio interaction
* separation of concerns (audio vs interaction)
* immersive spatial perception

---

## ✧ Future Enhancements

* networked multi-user performance sessions
* latency-aware synchronization
* advanced DSP integration
* DAW/plugin interoperability
* expanded spatial audio modeling

---

## ♡ Closing

CloudStage MR Studio explores a new interaction model:

> ✦ where movement becomes music,
> and space becomes part of the instrument ✦
