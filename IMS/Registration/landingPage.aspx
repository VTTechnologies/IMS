<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="landingPage.aspx.cs" Inherits="IMS.Registration.landingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="description" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- The above 4 meta tags *must* come first in the head; any other head content must come *after* these tags -->

    <!-- Title -->
    <title>IMS</title>

    <!-- Favicon -->
    <link rel="icon" href="../assets/Homeasst/img/core-img/favicon.ico">

    <!-- Core Stylesheet -->
    <link href="../assets/Homeasst/style.css" rel="stylesheet">

    <!-- Responsive CSS -->
    <link href="../assets/Homeasst/css/responsive.css" rel="stylesheet">

    <style>
         .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 60%;
            height: 90%;
            overflow-y: scroll;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <!-- Preloader Start -->
        <div id="preloader">
            <div class="colorlib-load"></div>
        </div>

        <!-- ***** Header Area Start ***** -->
        <header class="header_area animated">
            <div class="container-fluid">
                <div class="row align-items-center">
                    <!-- Menu Area Start -->
                    <div class="col-12 col-lg-10">
                        <div class="menu_area">
                            <nav class="navbar navbar-expand-lg navbar-light">
                                <!-- Logo -->
                                <a class="navbar-brand" href="#" style="font: 400 32px Lato, sans-serif;">!MS B!ZZ</a>
                                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#ca-navbar" aria-controls="ca-navbar" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
                                <!-- Menu Area -->
                                <div class="collapse navbar-collapse" id="ca-navbar">
                                    <ul class="navbar-nav ml-auto" id="nav">
                                        <li class="nav-item active"><a class="nav-link" href="#home">Home</a></li>
                                        <li class="nav-item"><a class="nav-link" href="#about">About</a></li>
                                        <li class="nav-item"><a class="nav-link" href="#features">Features</a></li>
                                        <!-- <li class="nav-item"><a class="nav-link" href="#screenshot">Screenshot</a></li> -->
                                        <%--<li class="nav-item"><a class="nav-link" href="#pricing">Pricing</a></li>--%>
                                        <li class="nav-item"><a class="nav-link" href="#testimonials">Testimonials</a></li>
                                        <!-- <li class="nav-item"><a class="nav-link" href="#team">Team</a></li> -->
                                        <li class="nav-item"><a class="nav-link" href="#contact">Contact</a></li>
                                    </ul>
                                    <div class="sing-up-button d-lg-none">
                                        <a href="Login.aspx">Login</a>
                                    </div>
                                </div>
                            </nav>
                        </div>
                    </div>
                    <!-- Signup btn -->
                    <div class="col-12 col-lg-2">
                        <div class="sing-up-button d-none d-lg-block">
                            <a href="Login.aspx">Login</a>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        <!-- ***** Header Area End ***** -->

        <!-- ***** Wellcome Area Start ***** -->
        <section class="wellcome_area clearfix" id="home">
            <div class="container h-100">
                <div class="row h-100 align-items-center">
                    <div class="col-12 col-md">
                        <div class="wellcome-heading">
                            <h2>IMS BIZZ</h2>
                            <h3>!MS </h3>
                            <p>Let us manage your business with IMSBIZZ</p>
                        </div>
                        <div class="get-start-area">
                            <!-- Form Start -->

                            <!-- <input type="email" class="form-control email" placeholder="name@company.com"> -->
                            <%--<input type="submit" class="submit" value="Get Started">--%>
                            <a href="Register.aspx" class="submit">Get Started</a>

                            <!-- Form End -->
                        </div>
                    </div>
                    <div class="col-8 col-md offset-1">
                        <img src="../assets/img/Offer.png" />
                    </div>
                    <%--<div class="col-4 col-md">
                        <img src="../assets/img/1.png"  />
                    </div>--%>
                </div>
            </div>
            <!-- Welcome thumb -->
            <div class="welcome-thumb wow fadeInDown" data-wow-delay="0.5s">
                <!--<img src="img/bg-img/welcome-img.png" alt="">-->
            </div>
        </section>
        <!-- ***** Wellcome Area End ***** -->

        <!-- ***** Special Area Start ***** -->
        <section class="special-area bg-white section_padding_100" id="about">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <!-- Section Heading Area -->
                        <div class="section-heading text-center">
                            <h2>Why Is It Special</h2>
                            <div class="line-shape"></div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <!-- Single Special Area -->
                    <div class="col-12 col-md-4">
                        <div class="single-special text-center wow fadeInUp" data-wow-delay="0.2s">
                            <div class="single-icon">
                                <i class="ti-mobile" aria-hidden="true"></i>
                            </div>
                            <h4>Easy to use</h4>
                            <p>IMS is built with the latest technology, user friendly design and having simple forms that can easily accessible for complex tasks. </p>
                        </div>
                    </div>
                    <!-- Single Special Area -->
                    <div class="col-12 col-md-4">
                        <div class="single-special text-center wow fadeInUp" data-wow-delay="0.4s">
                            <div class="single-icon">
                                <i class="ti-cloud-up" aria-hidden="true"></i>
                            </div>
                            <h4>Cloud Based</h4>
                            <p>
                                <!--We build pretty complex tools and this allows us to take designs and turn them into functional quickly and easily-->
                                IMS is a cloud-based inventory solution that gives businesses the ability to manage their inventory on any device and from any location
                            </p>
                        </div>
                    </div>
                    <!-- Single Special Area -->
                    <div class="col-12 col-md-4">
                        <div class="single-special text-center wow fadeInUp" data-wow-delay="0.6s">
                            <div class="single-icon">
                                <i class="ti-dashboard" aria-hidden="true"></i>
                            </div>
                            <h4>Attractive Dashboard</h4>
                            <p>IMS has an attractive dashboard where you can simply see an overview of your inventory status, top selling products and etc.</p>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Special Description Area -->
            <div class="special_description_area mt-150">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="special_description_img">
                                <img src="../assets/Homeasst/img/bg-img/special.png" alt="">
                            </div>
                        </div>
                        <div class="col-lg-6 col-xl-5 ml-xl-auto">
                            <div class="special_description_content">
                                <h2>Our Best Propositions for You!</h2>
                                <p>IMS is a cloud-based inventory management solution that gives businesses the ability to manage their inventory on any device and from any location. Create and manage sales orders, purchase orders, and other essential items to get orders flowing in and out of your warehouses.</p>
                                <div class="app-download-area">
                                    <!--<div class="app-download-btn wow fadeInUp" data-wow-delay="0.2s">
                                    <!-- Google Store Btn -->
                                    <!--<a href="#">
                                        <i class="fa fa-android"></i>
                                        <p class="mb-0"><span>available on</span> Google Store</p>
                                    </a>
                                </div>
                                <div class="app-download-btn wow fadeInDown" data-wow-delay="0.4s">-->
                                    <!-- Apple Store Btn -->
                                    <!--<a href="#">
                                        <i class="fa fa-apple"></i>
                                        <p class="mb-0"><span>available on</span> Apple Store</p>
                                    </a>
                                </div>-->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- ***** Special Area End ***** -->

        <!-- ***** Awesome Features Start ***** -->
        <section class="awesome-feature-area bg-white section_padding_0_50 clearfix" id="features">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <!-- Heading Text -->
                        <div class="section-heading text-center">
                            <h2>Awesome Features</h2>
                            <div class="line-shape"></div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <!-- Single Feature Start -->
                    <div class="col-12 col-sm-6 col-lg-4">
                        <div class="single-feature">
                            <i class="ti-dashboard" aria-hidden="true"></i>
                            <h5>Awesome Experience</h5>
                            <p>IMS has an attractive dashboard, User Friendly and responsive design, simple and meaningful forms, product reports, purchase order, sales order ect.</p>
                        </div>
                    </div>
                    <!-- Single Feature Start -->
                    <div class="col-12 col-sm-6 col-lg-4">
                        <div class="single-feature">
                            <i class="ti-pulse" aria-hidden="true"></i>
                            <h5>Fast and Simple</h5>
                            <p>With IMS there is no software to download. All you do is open a Web browser on any device connected to the Internet, then log into your IMS account and you have access to all of its features.</p>
                        </div>
                    </div>
                    <!-- Single Feature Start -->
                    <div class="col-12 col-sm-6 col-lg-4">
                        <div class="single-feature">
                            <i class="ti-user" aria-hidden="true"></i>
                            <h5>User Privacy</h5>
                            <p>User rights allow you to control who sees what in your IMS account. You can limit access to only those modules that your employees need in order to do their jobs. </p>
                        </div>
                    </div>
                    <!-- Single Feature Start -->
                    <div class="col-12 col-sm-6 col-lg-4">
                        <div class="single-feature">
                            <i class="ti-home" aria-hidden="true"></i>
                            <h5>Multiple Warehouses</h5>
                            <p>IMS lets you track your inventory in as many warehouses and sub-locations as you need.  You can easily find where your parts and products are supposed to be by their rack numbers.</p>
                        </div>
                    </div>
                    <!-- Single Feature Start -->
                    <div class="col-12 col-sm-6 col-lg-4">
                        <div class="single-feature">
                            <i class="ti-receipt" aria-hidden="true"></i>
                            <h5>Purchase Order</h5>
                            <p>Create and track purchase orders, generate PO reports to stay on top of trends, and print receiving tickets to ensure every  product that arrives at your warehouse matches up with what you ordered.</p>
                        </div>
                    </div>
                    <!-- Single Feature Start -->
                    <div class="col-12 col-sm-6 col-lg-4">
                        <div class="single-feature">
                            <i class="ti-receipt" aria-hidden="true"></i>
                            <h5>Sales Order</h5>
                            <p>The IMS Sales module helps you monitor customers and sales orders. Add tax rates and assign discounts on a per-customer basis, and then print invoices, pick tickets, and much more with this handy module.</p>
                        </div>
                    </div>
                </div>

            </div>
        </section>
        <!-- ***** Awesome Features End ***** -->

        <!-- ***** Video Area Start ***** -->
        <!--<div class="video-section">
        <div class="container">
            <div class="row">
                <div class="col-12">
                     Video Area Start 
                    <div class="video-area" style="background-image: url(img/bg-img/video.jpg);">
                        <div class="video-play-btn">
                            <a href="https://www.youtube.com/watch?v=f5BBJ4ySgpo" class="video_btn"><i class="fa fa-play" aria-hidden="true"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>-->
        <!-- ***** Video Area End ***** -->

        <!-- ***** Cool Facts Area Start ***** -->
        <!--<section class="cool_facts_area clearfix">
        <div class="container">
            <div class="row">-->
        <!-- Single Cool Fact-->
        <!--<div class="col-12 col-md-3 col-lg-3">
                    <div class="single-cool-fact d-flex justify-content-center wow fadeInUp" data-wow-delay="0.2s">
                        <div class="counter-area">
                            <h3><span class="counter">90</span></h3>
                        </div>
                        <div class="cool-facts-content">
                            <i class="ion-arrow-down-a"></i>
                            <p>APP <br> DOWNLOADS</p>
                        </div>
                    </div>
                </div>-->
        <!-- Single Cool Fact-->
        <!--<div class="col-12 col-md-3 col-lg-3">
                    <div class="single-cool-fact d-flex justify-content-center wow fadeInUp" data-wow-delay="0.4s">
                        <div class="counter-area">
                            <h3><span class="counter">120</span></h3>
                        </div>
                        <div class="cool-facts-content">
                            <i class="ion-happy-outline"></i>
                            <p>Happy <br> Clients</p>
                        </div>
                    </div>
                </div>-->
        <!-- Single Cool Fact-->
        <!--<div class="col-12 col-md-3 col-lg-3">
                    <div class="single-cool-fact d-flex justify-content-center wow fadeInUp" data-wow-delay="0.6s">
                        <div class="counter-area">
                            <h3><span class="counter">40</span></h3>
                        </div>
                        <div class="cool-facts-content">
                            <i class="ion-person"></i>
                            <p>ACTIVE <br>ACCOUNTS</p>
                        </div>
                    </div>
                </div>-->
        <!-- Single Cool Fact-->
        <!--<div class="col-12 col-md-3 col-lg-3">
                    <div class="single-cool-fact d-flex justify-content-center wow fadeInUp" data-wow-delay="0.8s">
                        <div class="counter-area">
                            <h3><span class="counter">10</span></h3>
                        </div>
                        <div class="cool-facts-content">
                            <i class="ion-ios-star-outline"></i>
                            <p>TOTAL <br>APP RATES</p>
                        </div>
                    </div>
                </div>-->
        <!--</div>
        </div>
    </section>-->
        <!-- ***** Cool Facts Area End ***** -->

        <!-- ***** App Screenshots Area Start ***** -->
        <!-- <section class="app-screenshots-area bg-white section_padding_0_100 clearfix" id="screenshot">
        <div class="container">
            <div class="row">
                <div class="col-12 text-center">
                    <!-- Heading Text  -->
        <!-- <div class="section-heading">
                        <h2>!MS B!ZZ Screenshots</h2>
                        <div class="line-shape"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <!-- App Screenshots Slides  -->
        <!-- <div class="app_screenshots_slides owl-carousel">
                        <div class="single-shot">
                            <img src="img/scr-img/app-1.jpg" alt="">
                        </div>
                        <div class="single-shot">
                            <img src="img/scr-img/app-2.jpg" alt="">
                        </div>
                        <div class="single-shot">
                            <img src="img/scr-img/app-3.jpg" alt="">
                        </div>
                        <div class="single-shot">
                            <img src="img/scr-img/app-4.jpg" alt="">
                        </div>
                        <div class="single-shot">
                            <img src="img/scr-img/app-5.jpg" alt="">
                        </div>
                        <div class="single-shot">
                            <img src="img/scr-img/app-3.jpg" alt="">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>   -->
        <!-- ***** App Screenshots Area End *****====== -->

        <%--Commented by ather for some time
        <!-- ***** Pricing Plane Area Start *****==== -->
        <section class="pricing-plane-area section_padding_100_70 clearfix" id="pricing">

            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <!-- Heading Text  -->
                        <div class="section-heading text-center">
                            <h2>Pricing Plan</h2>
                            <div class="line-shape"></div>
                        </div>
                    </div>

                </div>

                <div class="row no-gutters">
                    <div class="col-12 col-md-6 col-lg-3">
                        <!-- Package Price  -->
                        <div class="single-price-plan text-center">
                            <!-- Package Text  -->
                            <div class="package-plan">
                                <h5>Starter Plan</h5>
                                <div class="ca-price d-flex justify-content-center">
                                    <span>&#8377;</span>
                                    <h4>2899</h4>
                                </div>
                            </div>
                            <div class="package-description">
                                <p>3 Month Duration</p>
                                <p>Up to 10 users </p>
                                <p>Unlimited updates</p>
                                <!--<p>Free host &amp; domain</p>-->
                                <p>24/7 Support</p>
                                <!--<p>10 Unique Users</p>-->
                            </div>
                            <!-- Plan Button  -->
                            <div class="plan-button">
                                <a href="../Subscription/Pricing.aspx">Select Plan</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-6 col-lg-3">
                        <!-- Package Price  -->
                        <div class="single-price-plan text-center">
                            <!-- Package Text  -->
                            <div class="package-plan">
                                <h5>Basic Plan</h5>
                                <div class="ca-price d-flex justify-content-center">
                                    <span>&#8377;</span>
                                    <h4>5699</h4>
                                </div>
                            </div>
                            <div class="package-description">
                                <p>6 Month Duration</p>
                                <p>Up to 10 users </p>
                                <p>Unlimited updates</p>
                                <!--<p>Free host &amp; domain</p>-->
                                <p>24/7 Support</p>
                            </div>
                            <!-- Plan Button  -->
                            <div class="plan-button">
                                <a href="../Subscription/Pricing.aspx">Select Plan</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-6 col-lg-3">
                        <!-- Package Price  -->
                        <div class="single-price-plan active text-center">
                            <!-- Package Text  -->
                            <div class="package-plan">
                                <h5>Advanced Plan</h5>
                                <div class="ca-price d-flex justify-content-center">
                                    <span>&#8377;</span>
                                    <h4>9499</h4>
                                </div>
                            </div>
                            <div class="package-description">
                                <p>12 Month Duration</p>
                                <p>Up to 10 users </p>
                                <p>Unlimited updates</p>
                                <!--<p>Free host &amp; domain</p>-->
                                <p>24/7 Support</p>
                            </div>
                            <!-- Plan Button  -->
                            <div class="plan-button">
                                <a href="../Subscription/Pricing.aspx">Select Plan</a>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-md-6 col-lg-3">
                        <!-- Package Price  -->
                        <div class="single-price-plan text-center">
                            <!-- Package Text  -->
                            <div class="package-plan">
                                <h5>Community Plan</h5>
                                <div class="ca-price d-flex justify-content-center">
                                    <span>&#8377;</span>
                                    <h4>14999</h4>
                                </div>
                            </div>
                            <div class="package-description">
                                <p>18 Month Duration</p>
                                <p>Up to 10 users </p>
                                <p>Unlimited updates</p>
                                <!--<p>Free host &amp; domain</p>-->
                                <p>24/7 Support</p>
                            </div>
                            <!-- Plan Button  -->
                            <div class="plan-button">
                                <a href="../Subscription/Pricing.aspx">Select Plan</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- ***** Pricing Plane Area End ***** -->--%>

        <!-- ***** CTA Area Start ***** -->
        <section class="our-monthly-membership section_padding_50 clearfix">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-md-8">
                        <div class="membership-description">
                            <h2>Join our Monthly Membership</h2>
                            <p>Find the perfect plan for you — 100% satisfaction guaranteed.</p>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="get-started-button wow bounceInDown" data-wow-delay="0.5s">
                            <a href="Register.aspx">Get Started</a>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- ***** CTA Area End ***** -->

        <!-- ***** Client Feedback Area Start ***** -->
        <%--  <section class="clients-feedback-area bg-white section_padding_100 clearfix" id="testimonials">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-12 col-md-10">
                    <div class="slider slider-for">
                        <!-- Client Feedback Text  -->
                        <div class="client-feedback-text text-center">
                            <div class="client">
                                <i class="fa fa-quote-left" aria-hidden="true"></i>
                            </div>
                            <div class="client-description text-center">
                                <p>“ I have been using it for a number of years. I use IMS for usability testing. It's great for taking images and making clickable image prototypes that do the job and save me the coding time and just the general hassle of hosting. ”</p>
                            </div>
                            <div class="star-icon text-center">
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                            </div>
                            <div class="client-name text-center">
                                <h5>Aigars Silkalns</h5>
                                <p>Ceo IMS</p>
                            </div>
                        </div>
                        <!-- Client Feedback Text  -->
                        <div class="client-feedback-text text-center">
                            <div class="client">
                                <i class="fa fa-quote-left" aria-hidden="true"></i>
                            </div>
                            <div class="client-description text-center">
                                <p>“ I use IMS for usability testing. It's great for taking images and making clickable image prototypes that do the job and save me the coding time and just the general hassle of hosting. ”</p>
                            </div>
                            <div class="star-icon text-center">
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                            </div>
                            <div class="client-name text-center">
                                <h5>Jennifer</h5>
                                <p>Developer</p>
                            </div>
                        </div>
                        <!-- Client Feedback Text  -->
                        <div class="client-feedback-text text-center">
                            <div class="client">
                                <i class="fa fa-quote-left" aria-hidden="true"></i>
                            </div>
                            <div class="client-description text-center">
                                <p>“ I have been using it for a number of years. I use IMS for usability testing. It's great for taking images and making clickable image prototypes that do the job.”</p>
                            </div>
                            <div class="star-icon text-center">
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                            </div>
                            <div class="client-name text-center">
                                <h5>Helen</h5>
                                <p>Marketer</p>
                            </div>
                        </div>
                        <!-- Client Feedback Text  -->
                        <div class="client-feedback-text text-center">
                            <div class="client">
                                <i class="fa fa-quote-left" aria-hidden="true"></i>
                            </div>
                            <div class="client-description text-center">
                                <p>“ I have been using it for a number of years. I use IMS for usability testing. It's great for taking images and making clickable image prototypes that do the job and save me the coding time and just the general hassle of hosting. ”</p>
                            </div>
                            <div class="star-icon text-center">
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                                <i class="ion-ios-star"></i>
                            </div>
                            <div class="client-name text-center">
                                <h5>Henry smith</h5>
                                <p>Developer</p>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Client Thumbnail Area -->
                <div class="col-12 col-md-6 col-lg-5">
                    <div class="slider slider-nav">
                        <div class="client-thumbnail">
                            <img src="../assets/Homeasst/img/bg-img/client-3.jpg" alt="">
                        </div>
                        <div class="client-thumbnail">
                            <img src="../assets/Homeasst/img/bg-img/client-2.jpg" alt="">
                        </div>
                        <div class="client-thumbnail">
                            <img src="../assets/Homeasst/img/bg-img/client-1.jpg" alt="">
                        </div>
                        <div class="client-thumbnail">
                            <img src="../assets/Homeasst/img/bg-img/client-2.jpg" alt="">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>--%>
        <!-- ***** Client Feedback Area End ***** -->



        <!-- ***** Our Team Area Start ***** -->
        <!-- <section class="our-Team-area bg-white section_padding_100_50 clearfix" id="team">
        <div class="container">
            <div class="row">
                <div class="col-12 text-center">
                    <!-- Heading Text  -->
        <!-- <div class="section-heading">
                        <h2>Our Team</h2>
                        <div class="line-shape"></div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12 col-md-6 col-lg-3">
                    <div class="single-team-member">
                        <div class="member-image">
                            <img src="img/team-img/team-1.jpg" alt="">
                            <div class="team-hover-effects">
                                <div class="team-social-icon">
                                    <a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a>
                                    <a href="#"><i class="fa fa-twitter" aria-hidden="true"></i></a>
                                    <a href="#"><i class="fa fa-google-plus" aria-hidden="true"></i></a>
                                    <a href="#"> <i class="fa fa-instagram" aria-hidden="true"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="member-text">
                            <h4>Jackson Nash</h4>
                            <p>Tax Advice</p>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-3">
                    <div class="single-team-member">
                        <div class="member-image">
                            <img src="img/team-img/team-2.jpg" alt="">
                            <div class="team-hover-effects">
                                <div class="team-social-icon">
                                    <a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a>
                                    <a href="#"><i class="fa fa-twitter" aria-hidden="true"></i></a>
                                    <a href="#"><i class="fa fa-google-plus" aria-hidden="true"></i></a>
                                    <a href="#"> <i class="fa fa-instagram" aria-hidden="true"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="member-text">
                            <h4>Alex Manning</h4>
                            <p>CEO-Founder</p>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-3">
                    <div class="single-team-member">
                        <div class="member-image">
                            <img src="img/team-img/team-3.jpg" alt="">
                            <div class="team-hover-effects">
                                <div class="team-social-icon">
                                    <a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a>
                                    <a href="#"><i class="fa fa-twitter" aria-hidden="true"></i></a>
                                    <a href="#"><i class="fa fa-google-plus" aria-hidden="true"></i></a>
                                    <a href="#"> <i class="fa fa-instagram" aria-hidden="true"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="member-text">
                            <h4>Ollie Schneider</h4>
                            <p>Business Planner</p>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-3">
                    <div class="single-team-member">
                        <div class="member-image">
                            <img src="img/team-img/team-4.jpg" alt="">
                            <div class="team-hover-effects">
                                <div class="team-social-icon">
                                    <a href="#"><i class="fa fa-facebook" aria-hidden="true"></i></a>
                                    <a href="#"><i class="fa fa-twitter" aria-hidden="true"></i></a>
                                    <a href="#"><i class="fa fa-google-plus" aria-hidden="true"></i></a>
                                    <a href="#"> <i class="fa fa-instagram" aria-hidden="true"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="member-text">
                            <h4>Roger West</h4>
                            <p>Financer</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section> -->
        <!-- ***** Our Team Area End ***** -->

        <!-- ***** Contact Us Area Start ***** -->
        <section class="footer-contact-area section_padding_100 clearfix" id="contact">
            <div class="container">
                <div class="row">
                    <div class="col-md-6">
                        <!-- Heading Text  -->
                        <div class="section-heading">
                            <h2>Get in touch with us!</h2>
                            <div class="line-shape"></div>
                        </div>
                        <div class="footer-text">
                            <p>We'll send you epic weekly blogs, white papers and things to make your inventory and business keep going smoothly</p>
                        </div>
                        <div class="address-text">
                            <p><span>Address:</span> ZunMan Solutions, Himayat Bagh, opposit Maulana Azad college, Aurangabad, Maharashtra.</p>
                        </div>
                        <div class="phone-text">
                            <p><span>Phone:</span>  +91 2402381133</p>
                        </div>
                        <div class="email-text">
                            <p><span>Email:</span> contact@zunmansolutions.com</p>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <!-- Form Start-->
                        <div class="contact_from">

                            <!-- Message Input Area Start -->
                            <div class="contact_input_area">
                                <div class="row">
                                    <!-- Single Input Area Start -->
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <input type="text" class="form-control" name="name" id="name" runat="server" placeholder="Your Name" required>
                                        </div>
                                    </div>
                                    <!-- Single Input Area Start -->
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <input type="email" class="form-control" name="email" id="email" runat="server" placeholder="Your E-mail" required>
                                        </div>
                                    </div>
                                    <!-- Single Input Area Start -->
                                    <div class="col-12">
                                        <div class="form-group">
                                            <textarea name="message" class="form-control" id="message" runat="server" cols="30" rows="4" placeholder="Your Message *" required></textarea>
                                        </div>
                                    </div>
                                    <!-- Single Input Area Start -->
                                    <div class="col-12">

                                        <asp:Button ID="btnsubmit" runat="server" Text="Send Now" class="btn submit-btn" OnClick="btnsubmit_Click" />
                                    </div>
                                </div>
                            </div>
                            <!-- Message Input Area End -->

                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- ***** Contact Us Area End ***** -->

        <!-- ***** Footer Area Start ***** -->
        <footer class="footer-social-icon text-center section_padding_70 clearfix">
            <!-- footer logo -->
            <div class="footer-text">
                <h2>!MS B!ZZ</h2>
            </div>
            <!-- social icon-->
            <div class="footer-social-icon">
                <a href="https://www.facebook.com/zunmansolutions" target="_blank"><i class="fa fa-facebook" aria-hidden="true"></i></a>
                <a href="https://twitter.com/ZunmanSolutions" target="_blank"><i class="active fa fa-twitter" aria-hidden="true"></i></a>
                <a href="https://www.instagram.com/zunmansolutions/" target="_blank"><i class="fa fa-instagram" aria-hidden="true"></i></a>
                <a href="https://www.linkedin.com/company/zunmansolutions" target="_blank"><i class="fa fa-linkedin" aria-hidden="true"></i></a>
            </div>
            <div class="footer-menu">
                <nav>
                    <ul>
                        <li><a class="nav-link" href="#about">About</a></li>
                        <li><a href="#" data-toggle="modal" data-target="#termsAndCodintions">Terms &amp; Conditions</a></li>
                        <li><a href="#">Contact</a></li>
                    </ul>
                </nav>
            </div>
            <!-- Foooter Text-->
            <div class="copyright-text">
                <!-- ***** Removing this text is now allowed! This template is licensed under CC BY 3.0 ***** -->
                <p>Copyright
                    <script>document.write(new Date().getFullYear())</script>
                    !MS B!ZZ Designed by <a href="https://zunmansolutions.com/" target="_blank">ZunMan Solutions</a></p>
            </div>
        </footer>
        <!-- ***** Footer Area Start ***** -->

        <!-- ***** Terms And Conditions modal ***** -->
        <div class="modal fade" id="termsAndCodintions" role="dialog">
            <div class="modal-dialog" >
                <div class="modal-content" >
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body">
                        <table>
                            <tr>
                                <td class="content">
                                    <center>
                                <h1>Privacy Policy</h1>
                            </center>
                                    <h4 style="color: blueviolet">By using IMS BIZZ you are agreeing to be bound by the following terms and conditions (Terms of Service).</h4>
                                    <p>
                                        IMS BIZZ reserves right to update and change the terms of service from time to time without prior notice. Any new features that augment or enhance in current Service, shall be subject to the “Terms of Service”. Continued use of Service after any such changes shall constitute your consent to such changes. You can review the most current version of “terms of service” at any time at: Contact Us.
                                    </p>
                                    <p>
                                        You must provide your legal full name, a valid email address, and any other information requested in order to complete the signup process. Your login may only be used by one person – a single login shared by multiple people is not permitted. You may create separate logins for as many people as required. You are responsible for maintaining security of your account and password. IMS BIZZ cannot and will not be liable for any loss or damage from your failure to comply with this security obligation.
                                    </p>
                                    <p>
                                        You are responsible for all Content posted and activity that occurs under your account (even when Content is posted by others who have accounts under your account). You acknowledge that IMS BIZZ has no control over and no duty to take any action regarding what Content you access via the Services; what affects the Content may have on you; how you may interpret or use the Content; or what actions you may take as a result of having been exposed to the Content. You release IMS BIZZ from all liability for you having acquired or not acquired Content through the Services.
                                    </p>
                                    <p>
                                        We may, but have no obligation to, remove Content and Accounts containing Content that we determine in our sole discretion are unlawful, offensive, threatening, libelous, defamatory, obscene or otherwise objectionable or violates any party’s intellectual property or these Terms of Service. One person or legal entity may not maintain more than one free account. You may not use the Service for any illegal or unauthorized purpose. You must not, in use of the Service, violate any laws in your jurisdiction (including but not limited to copyright laws).
                                    </p>
                                    <h4 style="color: blueviolet">Organization Accounts and Account Administrators
                                    </h4>
                                    <p>
                                        When you sign up for an account for your organization you may specify one or more administrators. The administrators will have the right to configure the Services based on your requirements and manage end users in your organization account. If your organization account is created and configured on your behalf by a third party, it is likely that such third party has assumed administrator role for your organization. Make sure that you enter into a suitable agreement with such third party specifying such party’s roles and restrictions as an administrator of your organization account.
                                    </p>
                                    <p>
                                        You are responsible for it. I) ensuring confidentiality of your organization account password, ii) appointing competent individuals as administrators for managing your organization account, and iii) ensuring that all activities that occur in connection with your organization account comply with this Agreement. You understand that IMS BIZZ is not responsible for account administration and internal management of the Services for you.
                                    </p>
                                    <h4 style="color: blueviolet">Account Data
                                    </h4>
                                    <p>
                                        You and your End Users may choose to provide, post, input, submit, or otherwise make accessible to IMS BIZZ, data or information about you, your employees, customers, or any third party (“Data“), and IMS BIZZ may store such Data on your behalf, all in connection with your use of the Service. You hereby provide IMS BIZZ a limited non-exclusive, non-transferable license to use, upload, and store Data solely in connection with providing the Service.
                                    </p>
                                    <p>
                                        You represent and warrant that (I) you own all Data or have all rights that are necessary to grant IMS BIZZ the licensed rights in Data under these Terms; (ii) your collection of Data has and will be in compliance with all applicable laws and regulations, including without limitation those concerning data or information privacy; and (ii) neither the Data, nor the inclusion of Data in or use of Data in connection with the Service, will infringe, misappropriate or violate any Intellectual Property Rights, or violate the privacy rights, of any third party, or result in the violation of any applicable law or regulation, including without limitation those concerning data or information privacy. As between you and IMS BIZZ, you retain exclusive ownership of the Data. You acknowledge and agree that you remain solely responsible and liable for the Data. You may download your Data at any time during the Term, or as otherwise set forth herein, provided you comply with these Terms and IMS BIZZ security requirements.
                                    </p>
                                    <h4 style="color: blueviolet">Warranty Disclaimer
                                    </h4>
                                    <p>
                                        IMS BIZZ has no special relationship with or fiduciary duty to you. The Services, Content and Website are provided on an “as is” and “as available” basis, without warranties of any kind, either express or implied. IMS BIZZ does not warrant that (I) the service will meet your specific requirements, (ii) the service will be uninterrupted, timely, secure, or error-free, (iii) the results that may be obtained from the use of the service will be accurate or reliable, (iv) the quality of any products, services, information, or other material purchased or obtained by you through the service will meet your expectations, and (v) any errors in the Service will be corrected.
                                    </p>
                                    <h4 style="color: blueviolet">Personal Data
                                    </h4>
                                    <p>
                                        For information regarding IMS BIZZ treatment of personally identifiable information, please review IMS BIZZ current Privacy Policy, which is hereby incorporated by reference; your acceptance of this Agreement constitutes your acceptance and agreement to be bound by Company’s Privacy Policy.
                                    </p>
                                    <h4 style="color: blueviolet">Communications from IMSBIZZ
                                    </h4>
                                    <p>
                                        The Service may include certain communications from IMS BIZZ, such as service announcements, administrative messages and newsletters. You understand that these communications shall be considered part of using the Services. As part of our policy to provide you total privacy, we also provide you the option of opting out from receiving newsletters from us. However, you will not be able to opt-out from receiving service announcements and administrative messages.
                                    </p>
                                    <h4 style="color: blueviolet">Indemnity
                                    </h4>
                                    <p>
                                        You will indemnify and hold IMS BIZZ, its parents, subsidiaries, affiliates, officers, and employees harmless (including, without limitation, from all damages, liabilities, settlements, costs and attorneys’ fees) from any claim or demand made by any third party due to or arising out of your access to the Services, use of the Services, your violation of this Agreement, or the infringement by you of any intellectual property or other right of any person or entity.
                                    </p>
                                    <h4 style="color: blueviolet">Payment, Refunds, Upgrading and Downgrading Terms
                                    </h4>
                                    <p>
                                        A valid credit card is required for paying accounts. Trial accounts are not required to provide a credit card number. If you initially sign up for a paid account, and you don't cancel that account within the trial number of days. If you cancel prior to the processing of your first invoice, you will not be charged. If you subscribe to paid plan during your free trial you will be charged at the end of the trial period to ensure that you have the first 90 days i.e. the duration of the trial period, free of cost. You will be billed for your first month or year upon completion of the trial period. The Service is billed in advance, per your choosing, on a monthly or yearly basis and is non-refundable under any circumstances. There will be no refunds or credits for partial months of service, upgrade/downgrade refunds, or refunds for months unused with an open account. All fees are exclusive of all taxes, levies, or duties imposed by taxing authorities, and you shall be responsible for payment of all such taxes, levies, or duties, excluding only (state) taxes. For any upgrade or downgrade in plan level, your credit card that you provided will automatically be charged the new rate on your next billing cycle. Downgrading your Service may cause the loss of Content, features, or capacity of your Account. IMS BIZZ does not accept any liability for such loss.
                                    </p>
                                    <h4 style="color: blueviolet">Cancellation and Termination
                                    </h4>
                                    <p>
                                        You are solely responsible for properly canceling your account. An email or phone request to cancel your account is not considered cancellation. You can cancel your account at any time by clicking on the Settings link in the global navigation bar at the top of the screen. The Billing screen provides a simple cancellation/close account link. Please note that account data is not automatically removed upon cancellation as many of our customers re-activate their accounts after cancellation. We store all data permanently. In case you want your account data to be completely removed from the system, please email support@imsbizz.com with the request and we will have the account data removed. This information cannot be recovered once deleted.
                                If you cancel the Service before end of your current paid up month, your cancellation will take effect immediately and you will not be charged again. IMS BIZZ, in its sole discretion, has the right to suspend or terminate your account and refuse any and all current or future use of the Service, or any other IMS BIZZ service, for any reason at any time. Such termination of the Service will result in the deactivation or deletion of your Account or your access to your Account, and the forfeiture and relinquishment of all content in your Account. IMS BIZZ reserves the right to refuse service to anyone for any reason at any time.
                                    </p>
                                    <h4 style="color: blueviolet">Modifications to the Service and Prices
                                    </h4>
                                    <p>
                                        IMS BIZZ reserves the right at any time and from time to time to modify or discontinue, temporarily or permanently, the Service (or any part thereof) with or without notice. Prices of all Services, including but not limited to monthly subscription plan fees to the Service, are subject to change upon 30 days’ notice from us. Such notice may be provided at any time by emailing the changes and updating the pricing plan page on our website. IMS BIZZ shall not be liable to you or to any third party for any modification, price change, suspension or discontinuance of the Service.
                                    </p>
                                    <h4 style="color: blueviolet">Copyright and Content Ownership
                                    </h4>
                                    <p>
                                        All content posted on the Service must comply with copyright law. We claim no intellectual property rights over the material you provide to the Service. Your profile and materials uploaded remain yours. However, by setting your pages to be shared publicly, you agree to allow others to view and share your Content. IMS BIZZ does not pre-screen Content, but IMS BIZZ and its designee have the right (but not the obligation) in their sole discretion to refuse or remove any Content that is available via the Service.
                                    </p>
                                    <h4 style="color: blueviolet">General Conditions
                                    </h4>
                                    <p>
                                        Technical support is only available via email. You understand that IMS BIZZ uses third party vendors and hosting partners to provide necessary software, networking, Cloud storage, and related technology required to run the Service. You must not modify, adapt or hack the Service or modify another website so as to falsely imply that it is associated with the Service, IMS BIZZ or any other IMS BIZZ service. You agree not to reproduce, duplicate, copy, sell, resell or exploit any portion of the Service, use of the Service, or access to the Service without the express written permission by IMS BIZZ
                                    </p>
                                    <p>
                                        You understand that the technical processing and transmission of the Service, including your Content, may be transferred unencrypted and involve (a) submissions over various networks; and (b) changes to conform and adapt to technical requirements of connecting networks or devices. You must not upload, post, host, or transmit unsolicited email, SMSs, or “spam” messages. You must not transmit any worms or viruses or any code of a destructive nature. If your bandwidth significantly exceeds the average bandwidth usage (as determined solely by IMS BIZZ) of other customers, we reserve the right to immediately disable your account or throttle your file hosting until you can reduce your bandwidth consumption. IMS BIZZ may use your Company Names and Logos in case studies, promotional materials, or other write-ups, unless you request otherwise. You expressly understand and agree that IMS BIZZ shall not be liable for any direct, indirect, incidental, special, consequential or exemplary damages, including but not limited to, damages for loss of profits, goodwill, use, data or other intangible losses (even if IMS BIZZ has been advised of the possibility of such damages), resulting from: (I) the use or the inability to use the service; (ii) the cost of procurement of substitute goods and services resulting from any goods, data, information or services purchased or obtained or messages received or transactions entered into through or from the service; (iii) unauthorized access to or alteration of your transmissions or data; (iv) statements or conduct of any third party on the service; (v) or any other matter relating to the service. The failure of IMS BIZZ to exercise or enforce any right or provision of the Terms of Service shall not constitute a waiver of such right or provision. The Terms of Service and the Privacy Policy shall constitute the entire agreement between you and IMS BIZZ and govern your use of the Service, superseding any prior agreements between you and IMS BIZZ (including, but not limited to, any prior versions of the Terms of Service and Privacy Policy). Questions about the Terms of Service should be sent to support@imsbizz.com
                                    </p>
                                    <p style="color: blueviolet">
                                        Disclaimer: All the Legal Rights Judicial Officers Protection Act, 1850 jurisdiction only in Aurangabad.
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- ***** End Terms And Conditions modal ***** -->

        <!-- Jquery-2.2.4 JS -->
        <script src="../assets/Homeasst/js/jquery-2.2.4.min.js"></script>
        <!-- Popper js -->
        <script src="../assets/Homeasst/js/popper.min.js"></script>
        <!-- Bootstrap-4 Beta JS -->
        <script src="../assets/Homeasst/js/bootstrap.min.js"></script>
        <!-- All Plugins JS -->
        <script src="../assets/Homeasst/js/plugins.js"></script>
        <!-- Slick Slider Js-->
        <script src="../assets/Homeasst/js/slick.min.js"></script>
        <!-- Footer Reveal JS -->
        <script src="../assets/Homeasst/js/footer-reveal.min.js"></script>
        <!-- Active JS -->
        <script src="../assets/Homeasst/js/active.js"></script>
    </form>
</body>
</html>
