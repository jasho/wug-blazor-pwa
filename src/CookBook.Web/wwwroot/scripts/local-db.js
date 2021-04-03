let db;

window.LocalDb = {
    Initialize: function (interop) {
        db = new Dexie('cookbook_database');
        db.version(1).stores({
            recipes: 'id, name, description'
        });
    },
    Insert: function (entity) {
        db.table("recipes").put(entity);
    },
    Remove: async function (id) {
        await db.table("recipes").bulkDelete([id]);
    },
    GetById: async function (id) {
        let recipe = await db.table("recipes").get(id);
        return recipe;
    }
};
