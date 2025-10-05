// @ts-check
import { defineConfig } from "astro/config";

// https://astro.build/config
export default defineConfig({
  redirects: {
    "/": "/usuario-consulta",
  },
  vite: {
    resolve: {
      alias: {
        "@": "/src",
        "@layouts": "/src/layouts",
        "@components": "/src/components",
        "@models": "/src/models",
        "@assets": "/src/assets",
        "@globals": "/src/globals",
        "@pages": "/src/pages",
        "@utils": "/src/utils",
        "@config": "/src/config",
      },
    },
  },
});
