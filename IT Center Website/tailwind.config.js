/** @type {import('tailwindcss').Config} */
module.exports = {
    mode: "jit",
    
    content: ["./Pages/**/*.{cshtml,razor}", "./Components/**/*.{cshtml,razor}", "./wwwroot/js/**/*.js"],
    theme: {
        extend: {},
    },
    plugins: [],
}

