var swiper = new Swiper(".mySwiper", {
    effect: "coverflow",
    grabCursor: true,
    centeredSlides: true,
    slidesPerView: "auto",
    rewind: true,

    autoplay: {
        delay: 2500,
        disableOnInteraction: false,
    },
    coverflowEffect: {
        rotate: 50,
        stretch: 0,
        depth: 100,
        modifier: 1,
        slideShadows: true,
    },
    pagination: {
        el: ".swiper-pagination",
    },
});

// Password visibility toggle
document.getElementById('togglePassword').addEventListener('click', function () {
    const passwordInput = document.getElementById('password');
    const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
    passwordInput.setAttribute('type', type);

    // Toggle icon
    const icon = this.getAttribute('uk-icon') === 'icon: eye' ? 'icon: eye-slash' : 'icon: eye';
    this.setAttribute('uk-icon', icon);
});

// Form submission
document.querySelector('form').addEventListener('submit', function (e) {
    e.preventDefault();
    // In a real app, you would handle login here
    alert('Login functionality would be implemented here');
});