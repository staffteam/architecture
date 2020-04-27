var Auth = {
	vars: {
		option: {}
	},
	register(e) {
		$('.lowin-login').addClass('lowin-animated');
		setTimeout(() => {
			$('.lowin-login').hide();
		}, 500);
		$('.lowin-register').show().addClass('lowin-animated-flip');
		Auth.setHeight($('.lowin-register').height() + $('.lowin-footer').height());

		e.preventDefault();
	},
	forget(e) {
		$('.lowin-login').addClass('lowin-animated');
		setTimeout(() => {
			$('.lowin-login').hide();
		}, 500);
		$('.lowin-forget').show().addClass('lowin-animated-flip');
		Auth.setHeight($('.lowin-forget').height() + $('.lowin-footer').height());

		e.preventDefault();
	},
	login(e) {
		$('.lowin-register').removeClass('lowin-animated-flip').addClass('lowin-animated-flipback');
		$('.lowin-login').show().removeClass('lowin-flip').removeClass('lowin-animated').addClass('lowin-animatedback');
		setTimeout(() => {
			$('.lowin-register').hide();
		}, 500);

		setTimeout(() => {
			$('.lowin-register').removeClass('lowin-animated-flipback');
			$('.lowin-login').removeClass('lowin-animatedback');
		}, 1000);

		Auth.setHeight($('.lowin-login').height() + $('.lowin-footer').height());

		e.preventDefault();
	},
	backlogin(e) {
		$('.lowin-forget').removeClass('lowin-animated-flip');
		$('.lowin-forget').addClass('lowin-animated-flipback');
		$('.lowin-login').show();
		$('.lowin-login').removeClass('lowin-animated');
		$('.lowin-login').addClass('lowin-animatedback');
		setTimeout(() => {
			$('.lowin-forget').hide();
		}, 500);

		setTimeout(() => {
			$('.lowin-forget').removeClass('lowin-animated-flipback');
			$('.lowin-login').removeClass('lowin-animatedback');
		}, 1000);

		Auth.setHeight($('.lowin-login').height() + $('.lowin-footer').height());

		e.preventDefault();
	},
	setHeight(height) {
		$('.lowin-wrapper').css('min-height',height+'px');
	},
	brand() {
		$('.lowin input').val('');
		$('.lowin-brand').addClass('lowin-animated');
		setTimeout(() => {
			$('.lowin-brand').removeClass('lowin-animated');
		}, 1000);
	},
	init(option) {
		Auth.setHeight($('.lowin-box').height() + $('.lowin-footer').height());

		$('.password-group').height($('.password-group').height() + 'px');
		Auth.vars.option = option;
		$('.lowin-box').not('.lowin-login').addClass('lowin-flip');
		// Auth.vars.forgot_link.addEventListener("click", (e) => {
		// 	Auth.forgot(e);
		// });

		$('.register-link').on("click", function (e) {
			Auth.brand();
			Auth.register(e);
		});
		$('.forget-link').on("click", function (e) {
			Auth.brand();
			Auth.forget(e);
		});
		$('.login-link').click(function (e) {
			Auth.brand();
			$(this).closest('.lowin-register').length > 0 ? Auth.login(e) : Auth.backlogin(e);
		});
	}
}