<script>
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';

	const lines = [
		'const myRandomBgm = random_song(400, 409)',
		'',
		'encounter["Normal Battles"]:',
		'  music = myRandomBgm',
		'end'
	];
</script>

<h1>Adding Randomized BGM</h1>
<p>
	The main feature people usually want from a BGM mod, and one of the easiest things to add in any
	game.
</p>
<h2>Requirements</h2>
<ul>
	<li>BGME Framework</li>
	<li><Link url="{base}/guides/create-mod">Created a Music Mod with BGME Framework</Link></li>
	<li>Have your music script file opened in a text editor</li>
</ul>
<h2>The Music Script</h2>
<pre><code>{lines.join('\n')}</code></pre>
<p>
	With just 4 lines of code, all normal battles now have randomized BGM. Let's break down what each
	line does.
</p>
<h3>Creating Random BGM</h3>
<pre><code>{lines[0]}</code></pre>
<p>
	This line creates a <b>constant</b> named <em>myRandomBgm</em>. Constants are like variables in
	math: if x = 42, then x + 1 = 43.
</p>
<p>
	In this case, <em>myRandomBgm</em> is being set to equal <code>random_song(400, 409)</code>.
</p>
<p>
	What <code>random_song(400, 409)</code> does is randomly play a BGM ID between 400, the
	<b>minimum ID</b>, and 409, the <b>maximum ID</b>.
</p>
<p>
	Now, whenever you use <em>myRandomBgm</em>, it'll randomly play a BGM ID between 400 and 409 for a
	total of 10 possible songs.
</p>
<h3>Selecting the Battle(s)</h3>
<pre><code>{lines[2]}</code></pre>
<p>
	This is the start of an <b>Encounter Block</b>. Encounter is just another name for battles.
	Encounter Blocks are what you use to change battle music.
</p>
<p>
	Between the <code>[ ]</code> brackets, you enter what battle(s) you want to change. In this case,
	what we're changing are <em>Normal Battles</em>, which is a <b>Collection</b>. Collections are
	just a collection of numbers representing an ID.
</p>
<blockquote>
	If you're starting out, stick to premade battle <Link url="{base}/docs/collections"
		>Collections</Link
	>. More advanced users can use <b>Encounter IDs</b>, if needed.
</blockquote>
<p>
	Notice that <em>Normal Battles</em> is surrounded by
	<b>" "</b> double quotes. <b>Always surround with double quotes when using collection names.</b>
</p>
<h3>Setting the Music</h3>
<pre><code>{lines[3]}</code></pre>
<p>
	Finally, you set the music for the battle(s). Probably the easiest line to understand, nothing to
	say really.
</p>
<pre><code>{lines[4]}</code></pre>
<p>
	The End (of the Encounter Block). Every type of block needs to be ended by having <code>end</code>
	at the end.
</p>
<h2>Finished</h2>
<p>
	Save your music script, add audio tracks for BGM IDs 400 to 409, then test in-game... if you're
	playing Persona 3 Portable. Other games require the BGM IDs used to be adjusted, see: <Link
		url="{base}/guides/new-music">Using New Music</Link
	>
</p>
<p>
	<b>Continue: <Link url="{base}/guides/boss-music">Custom Boss Music</Link></b>
</p>
<p>
	<b
		>Continue: <Link url="{base}/guides/battle-bgm"
			>Custom Battle BGM (Advantage, Disadvantage, Victory)</Link
		></b
	>
</p>
<p>
	For other features, such as <b>Floor BGM</b> and <b>Event BGM</b>, <Link url="{base}/docs"
		>read the docs.</Link
	>
</p>
