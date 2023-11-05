<script lang="ts">
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';
	import { randomSongExample } from '../Examples';
	import GameNotice from '../GameNotice.svelte';

	$: example = $randomSongExample;
</script>

<h1>Adding Randomized BGM</h1>
<p>
	The main feature people usually want from a BGM mod, and one of the easiest things to add in any
	game.
</p>
<h2>Requirements</h2>
like
<ul>
	<li>BGME Framework</li>
	<li><Link url="{base}/guides/create-mod">Created a Music Mod with BGME Framework</Link></li>
	<li>Have your music script file opened in a text editor</li>
</ul>
<h2>The Music Script</h2>
<pre><code>{example.code.join('\n')}</code></pre>
<p>
	With just 4 lines of code, all normal battles now have randomized BGM. Let's break down what each
	line does.
</p>
<h3>Creating Random BGM</h3>
<pre><code>{example.code[0]}</code></pre>
<p>
	This line creates a <b>constant</b> named <em>myRandomBgm</em>. Constants are like variables in
	math: if x = 42, then x + 1 = 43.
</p>
<p>
	In this case, <em>myRandomBgm</em> is being set to equal <code>{example.func}</code>.
</p>
<p>
	What <code>{example.func}</code> does is randomly play a BGM ID between {example.settings?.minId},
	the
	<b>minimum ID</b>, and {example.settings?.maxId}, the <b>maximum ID</b>.
</p>
<p>
	Now, whenever you use <em>myRandomBgm</em>, it'll randomly play a BGM ID between {example.settings
		?.minId}
	and {example.settings?.maxId} for a total of 10 possible songs.
</p>
<h3>Selecting the Battle(s)</h3>
<pre><code>{example.code[2]}</code></pre>
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
<pre><code>{example.code[3]}</code></pre>
<p>
	Finally, you set the music for the battle(s). Probably the easiest line to understand, nothing to
	say really.
</p>
<pre><code>{example.code[4]}</code></pre>
<p>
	The End (of the Encounter Block). Every type of block needs to be ended by having <code>end</code>
	at the end.
</p>
<h2>Finished</h2>
<GameNotice />
<p>
	Save your music script, add audio tracks for BGM IDs {example.settings?.minId} to {example
		.settings?.maxId} according to the instructions at: <Link url="{base}/guides/new-music"
		>Using New Music</Link
	>, then test in-game.
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
