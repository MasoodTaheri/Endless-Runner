# Endless-Runner, a 24-Hour Game Development Challenge

A minimalist yet architecturally robust game prototype built within a 24-hour development window. While visual polish was limited by time constraints, the foundation emphasizes scalability, maintainability, and SOLID principles—proving rapid development doesn’t require technical debt.
Key Architectural Highlights
🧩 SOLID-Centric Design

    Dependency Inversion implemented without frameworks (e.g., no Zenject), ensuring pure loose coupling and testability.

    Strict separation of concerns across modules (player logic, spawn systems, UI).

🛠️ Data-Driven Development

    Scriptable Objects centralize game data (items, obstacles, settings), enabling designer-friendly tuning:

        Adjust spawn rates, speeds, or rewards without code changes.

🖥️ Clean Architecture Patterns

    MVP/MVC patterns decouple UI from core logic (e.g., score updates, game state).

⚡ Performance Optimizations

    Object pooling for buildings, obstacles, and collectibles to eliminate instantiation overhead.

    Dynamic spawn/recycle systems ensure smooth gameplay even under load.

🔍 Future-Proofed for Expansion
The system is structured to seamlessly integrate:

    New power-ups, levels, or mechanics

    Broader game loops (e.g., procedural generation)
