# Interactive Witch Spellcasting System

## Project Description

An interactive Unity experience featuring three animated witches that cast spells in response to player input. Players select a witch and cast different spells using keyboard keys or UI buttons, triggering corresponding animations and audio effects. The system uses a centralized manager architecture to coordinate character control, user input, and UI state.

---

## Controls and Interactions

### Keyboard
- **E:** Cast Spell 1
- **R:** Cast Spell 2
- **T:** Cast Spell 3
- **Space:** Cast Ultimate Spell

### UI Buttons
- **Witch Selection Screen:** Choose Frost, Fire, or Shadow witch
- **Spellcasting Screen:** Cast spells 1-3 or Ultimate spell
- **Settings Screen:** Adjust volume slider and mute toggle

---

## System Architecture

### Core Managers

**GameManager**
- Tracks which witch is currently active
- Provides references to the active witch for other systems

**WitchController** (on each witch)
- Triggers animations via the Animator
- Plays sound effects when spells are cast
- Handles witch activation/deactivation

**InteractionManager**
- Monitors keyboard input (E, R, T, Space)
- Calls spell methods on the active witch
- Ensures only the selected witch responds to input

**UIManager**
- Manages screen transitions (Selection → Spellcasting → Settings)
- Handles witch selection and button clicks
- Controls volume and mute settings

**Animator Controllers** (one per witch)
- 5 states: Idle, Spell1, Spell2, Spell3, Ultimate
- Parameter `spellType` (int): determines which spell to play
- Trigger `ultimate`: activates ultimate spell
- Transitions auto-return to Idle after animation completes

### Data Flow

```
User Input → InteractionManager/UIManager
           → GameManager (identifies active witch)
           → WitchController (active witch only)
           → Animator (plays animation)
           → AudioSource (plays sound)
```

### Key Design

- **Single Active Witch:** Only selected witch is active; others deactivated
- **Animator-Driven:** Spell animations automatically return to Idle via Exit Time 1.0
- **Separation of Concerns:** Each manager handles one responsibility
- **Reusable:** New witches added by duplicating controller and animator setup

---

## Project Structure

```
Assets/
├── Witches/ (3 witch folders with models, animations, WitchController)
├── Managers/ (GameManager, InteractionManager, UIManager)
├── Audio/ (spell sounds and background music)
├── UI/ (canvas screens)
└── Scenes/ (Main.unity)
```
