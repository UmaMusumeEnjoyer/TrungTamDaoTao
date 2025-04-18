window.addEventListener('DOMContentLoaded', () => {
    gsap.from('.hero h2', {
        duration: 1,
        opacity: 0,
        y: -50
    });

    gsap.from('.cta-button', {
        duration: 1,
        opacity: 0,
        x: -100,
        delay: 0.5
    });

    gsap.from('.course-item', {
        duration: 1,
        opacity: 0,
        y: 50,
        stagger: 0.3
    });

    gsap.from('.testimonial-item', {
        duration: 1,
        opacity: 0,
        y: 50,
        stagger: 0.2
    });
});
